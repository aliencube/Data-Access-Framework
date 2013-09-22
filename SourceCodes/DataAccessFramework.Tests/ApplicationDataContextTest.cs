using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
		[TestCase("SampleDataContext", true)]
		public void ConnectDatabase_GetConnectionString_DatabaseConnected(string connectionName, bool connected)
		{
			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString))
			{
				connection.Open();
				Assert.AreEqual(connected, connection.State == ConnectionState.Open);
			}
		}

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
