using System;
using System.Collections.Generic;
using System.Text;

using Segment.Model;
using Segment.Delegates;

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
