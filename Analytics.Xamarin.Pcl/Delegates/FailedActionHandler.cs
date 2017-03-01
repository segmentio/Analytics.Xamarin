using System;
using Segment.Model;

namespace Segment.Delegates
{
	public delegate void FailedActionHandler(BaseAction action, System.Exception e);
}