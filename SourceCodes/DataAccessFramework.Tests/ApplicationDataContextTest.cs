using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
			var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				Assert.AreEqual(connected, connection.State == ConnectionState.Open);
			}
		}

		[Test]
		[TestCase("SampleDataContext", true)]
		public void ConnectDbContext_GetConnectionString_DbContextConnected(string connectionName, bool connected)
		{
			var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
			using (var context = new ApplicationDataContext(connectionString))
			{
				Assert.AreEqual(connected, context.Database.Exists());
			}
		}

		[Test]
		[TestCase("joebloggs", "abc123", "joe@test.org", true)]
		[TestCase("jackandjill", "abc123", "jj@test.org", true)]
		public void CreateUsers_GetUserDetails_UserAdded(string username, string password, string email, bool added)
		{
			const string connectionName = "SampleDataContext";
			var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
			using (var context = new ApplicationDataContext(connectionString))
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
