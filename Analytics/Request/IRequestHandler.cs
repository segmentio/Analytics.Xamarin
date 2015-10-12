using System;
using Segment.Delegates;
using Segment.Model;

namespace Segment.Request
{
	internal interface IRequestHandler : IDisposable
	{
		/// <summary>
		/// Send an action batch to the Segment tracking API.
		/// </summary>
		/// <param name="batch">Batch.</param>
		void SendBatch(Batch batch); 

		/// <summary>
		/// Occurs when an action fails.
		/// </summary>
		event FailedActionHandler Failed;

		/// <summary>
		/// Occurs when an action succeeds.
		/// </summary>
		event SucceededActionHandler Succeeded;

	}
}
