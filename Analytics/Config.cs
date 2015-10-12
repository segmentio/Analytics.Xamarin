using System;

namespace Segment
{
    /// <summary>
    /// Config required to initialize the client
    /// </summary>
	public class Config
    {

        /// <summary>
        /// The REST API endpoint
        /// </summary>
        internal string Host { get; set; }

        internal int MaxQueueSize { get; set; }

		internal bool Async { get; set; }

		internal TimeSpan Timeout { get; set; }

		public Config()
        {
            Host = Defaults.Host;
			Timeout = Defaults.Timeout;
            MaxQueueSize = Defaults.MaxQueueCapacity;
			Async = Defaults.Async;
        }

		/// <summary>
		/// Sets the maximum amount of timeout on the HTTP request flushes to the server.
		/// </summary>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public Config SetTimeout(TimeSpan timeout)
		{
			Timeout = timeout;
			return this;
		}
		
		/// <summary>
		/// Sets the maximum amount of items that can be in the queue before no more are accepted.
		/// </summary>
		/// <param name="maxQueueSize"></param>
		/// <returns></returns>
		public Config SetMaxQueueSize(int maxQueueSize)
		{
			MaxQueueSize = maxQueueSize;
			return this;
		}

        /// <summary>
        /// Sets whether the flushing to the server is synchronous or asynchronous.
		/// 
		/// True is the default and will allow your calls to Analytics.Client.Identify(...), Track(...), etc
		/// to return immediately and to be queued to be flushed on a different thread.
		/// 
		/// False is convenient for testing but should not be used in production. False will cause the 
		/// HTTP requests to happen immediately.
		/// 
        /// </summary>
		/// <param name="async">True for async flushing, false for blocking flushing</param>
        /// <returns></returns>
		public Config SetAsync(bool async)
        {
			Async = async;
            return this;
        }
    }
}
