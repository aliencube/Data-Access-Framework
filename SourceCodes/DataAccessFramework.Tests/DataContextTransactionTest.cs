using System;
using System.Configuration;
using NUnit.Framework;
using NSubstitute;

namespace DataAccessFramework.Tests
{
    [TestFixture]
    public class DataContextTransactionTest
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
