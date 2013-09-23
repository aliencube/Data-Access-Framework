using DataAccessFramework.Configuration;
using DataAccessFramework.Helpers;
using NUnit.Framework;
using System;
using System.Configuration;

namespace DataAccessFramework.Tests
{
    [TestFixture]
    public class DataContextTransactionTest
    {
        private ConnectionHelper _helper;
        private ApplicationDataContext _context;

        #region SetUp / TearDown

        [TestFixtureSetUp]
        public void Init()
        {
            var settings = (ConnectionSettings) ConfigurationManager.GetSection("connectionSettings");
            this._helper = new ConnectionHelper(settings);
            this._context = new ApplicationDataContext(this._helper.GetConnectionString(0));
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            this._helper.Dispose();
            this._context.Dispose();
        }

        #endregion SetUp / TearDown

        #region Connection

        [Test]
        public void GetContext_ContextOpen()
        {
            Assert.IsTrue(this._context.Database.Exists());
        }

        #endregion

        #region Addition

        [Test]
        [TestCase("joebloggs", "abcd1234", "joe@test.org", true)]
        [TestCase("jackandjill", "abcd1234", "jj@test.org", true)]
        public void CreateUsers_GetUserDetails_UserAdded(string username, string password, string email, bool added)
        {
            var user = new User()
                       {
                           Username = username,
                           Password = password,
                           Email = email,
                           DateCreated = DateTime.Now,
                           CreatedBy = 0
                       };
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }

        #endregion Addition
    }
}