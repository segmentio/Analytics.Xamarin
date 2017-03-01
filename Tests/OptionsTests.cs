using NUnit.Framework;
using Segment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestFixture]
	public class OptionsTests
	{
		[Test]
		public void BaseActionCopiesAnonId()
		{
			var options = new Options()
			{
				AnonymousId = "catpants"
			};

			var action = new Screen("", "", "", null, options);
			Assert.AreEqual("catpants", action.AnonymousId);
		}

	}
}
