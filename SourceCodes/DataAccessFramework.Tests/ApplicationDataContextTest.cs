using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NSubstitute;

namespace DataAccessFramework.Tests
{
	[TestFixture]
	public class ApplicationDataContextTest
	{
		#region SetUp / TearDown

		[SetUp]
		public void Init()
		{ }

		[TearDown]
		public void Dispose()
		{ }

		#endregion

		#region Tests

		[Test]
		[TestCase("joebloggs", "abc123", "joe@test.org", true)]
		[TestCase("jackandjill", "abc123", "jj@test.org", true)]
		public void CreateUsers_GetUserDetails_UserAdded(string username, string password, string email, bool added)
		{
			using (var context = new ApplicationDataContext())
			{
				var user = new User()
					{
						Username = username,
						Password = password,
						Email = email,
						DateCreated = DateTime.Now,
						CreatedBy = 0
					};
				context.Users.Add(user);
				context.SaveChanges();
			}
		}

		#endregion
	}
}
