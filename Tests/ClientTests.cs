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

			protected override void Initialize(string writeKey, Config config)
			{
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

		[Test]
		public void initConfig()
		{
			var test = new Client(Segment.Test.Constants.WRITE_KEY);
			Assert.IsNotNull(test.Config);
		}

		[Test]
		public void initConfig_1()
		{
			var test = new Client(Segment.Test.Constants.WRITE_KEY, new Config());
			Assert.IsNotNull(test.Config);
		}

		[Test]
		public void initConfig_2()
		{
			var test = new Client(Segment.Test.Constants.WRITE_KEY, null);
			Assert.IsNotNull(test.Config);
		}

		[Test]
		public void initConfig_3()
		{
			var test = new Client(Segment.Test.Constants.WRITE_KEY);
			Assert.IsNotNull(test.Config);
		}

		[Test]
		public void initConfig_4()
		{
			var test = new Client(Segment.Test.Constants.WRITE_KEY, new Config());
			Assert.IsNotNull(test.Config);
		}

		[Test]
		public void initConfig_5()
		{
			var test = new Client(Segment.Test.Constants.WRITE_KEY, null);
			Assert.IsNotNull(test.Config);
		}
	}
}
