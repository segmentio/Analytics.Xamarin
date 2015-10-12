using System.Collections.Generic;
using Segment.Model;

namespace Segment.Flush
{
	internal class SimpleBatchFactory : IBatchFactory
	{
		private readonly string _writeKey;

		internal SimpleBatchFactory (string writeKey)
		{
			_writeKey = writeKey;
		}

		public Batch Create(List<BaseAction> actions) 
		{
			return new Batch(_writeKey, actions);
		}
	}
}

