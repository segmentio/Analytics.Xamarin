using NUnit.Framework;
using Segment;
using Segment.Model;
using System;

namespace Tests
{
	[TestFixture]
	public class ClientTests
	{
		class TestClient : Client
		{
			public TestClient() : base("catpants")
			{
			}

			public bool EnsureId(String userId, Options options)
			{
				try
				{
					base.ensureId(userId, options);
				}
				catch
				{
					return false;
				}

				return true;
			}
		}

		[Test]
		public void HasUserId_NoOptions()
		{
			var test = new TestClient();
			Assert.IsTrue(test.EnsureId("user id", null));
		}

		[Test]
		public void NoUserId_HasAnonId()
		{
			var test = new TestClient();

			Assert.IsTrue(test.EnsureId("", new Options()
			{
				AnonymousId = "anon id"
			}));
		}

		[Test]
		public void NoUserId_NoAnon()
		{
			var test = new TestClient();

			Assert.IsFalse(test.EnsureId("", new Options()));
		}

		[Test]
		public void NoUserId_NoOptions()
		{
			var test = new TestClient();

			Assert.IsFalse(test.EnsureId("", null));
		}
	}
}
