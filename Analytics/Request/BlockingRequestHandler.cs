using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Segment.Model;
using Segment.Exception;
using Segment.Delegates;

namespace Segment.Request
{
	internal class BlockingRequestHandler : IRequestHandler
	{
		/// <summary>
		/// Occurs when an action fails.
		/// </summary>
		public event FailedActionHandler Failed;

		/// <summary>
		/// Occurs when an action succeeds.
		/// </summary>
		public event SucceededActionHandler Succeeded;

		/// <summary>
		/// Segment API endpoint.
		/// </summary>
		private string _host;

		/// <summary>
		/// Http client
		/// </summary>
		private HttpClient _client;

		internal BlockingRequestHandler (string host, TimeSpan timeout)
		{
			this._host = host;
			this._client = new HttpClient ();
			this._client.Timeout = timeout;
			// do not use the expect 100-continue behavior
			this._client.DefaultRequestHeaders.ExpectContinue = false;
		}

		public void SendBatch(Batch batch)
		{
			Dict props = new Dict {
				{ "batch id", batch.MessageId },
				{ "batch size", batch.batch.Count }
			};

			try
			{
				// set the current request time
				batch.SentAt = DateTime.Now.ToString("o");
				string json = JsonConvert.SerializeObject(batch);
				props["json size"] = json.Length;

				Uri uri = new Uri(_host + "/v1/import");

				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);

				// basic auth: https://segment.io/docs/tracking-api/reference/#authentication
				request.Headers.Add("Authorization", BasicAuthHeader(batch.WriteKey, ""));
				request.Content = new StringContent(json, Encoding.UTF8, "application/json");

				Logger.Info("Sending analytics request to Segment.io ..", props);

				var start = DateTime.Now;
			
				var response = _client.SendAsync(request).Result;

				var duration = DateTime.Now - start;
				props["success"] = response.IsSuccessStatusCode;
				props["duration (ms)"] = duration.TotalMilliseconds;

				if (response.IsSuccessStatusCode) {
					Succeed(batch);
					Logger.Info("Request successful", props);
				}
				else {
					string reason = string.Format("Status Code {0} ", response.StatusCode);
					reason += response.Content.ToString();
					props["reason"] = reason;
					Logger.Error("Request failed", props);
					Fail(batch, new APIException("Unexpected Status Code", reason));
				}
			}
			catch (System.Exception e)
			{
				props ["reason"] = e.Message;
				Logger.Error ("Request failed", props);
				Fail(batch, e);
			}
		}

		private void Fail(Batch batch, System.Exception e) 
		{
			foreach (BaseAction action in batch.batch)
			{
				if (Failed != null) {
					Failed (action, e);
				}
			}
		}


		private void Succeed(Batch batch) 
		{
			foreach (BaseAction action in batch.batch)
			{
				if (Succeeded != null) {
					Succeeded (action);
				}
			}
		}

		private string BasicAuthHeader(string user, string pass) 
		{
			string val = user + ":" + pass;
			return  "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(val));
		}

		public void Dispose() {
			_client.Dispose ();
		}
	}
}

