using DataAccessFramework.Configuration;
using DataAccessFramework.Configuration.Interfaces;
using DataAccessFramework.Entities;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Linq;

namespace DataAccessFramework.Tests
{
    [TestFixture]
    public class DataContextTransactionTest
    {
        private IConnectionBuilder _builder;
        private ApplicationDataContext _context;

        #region SetUp / TearDown

        [TestFixtureSetUp]
        public void Init()
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            this._builder = new ConnectionBuilder(settings);
            this._context = new ApplicationDataContext(this._builder.GetConnectionString(0));
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            this._builder.Dispose();
            this._context.Dispose();
        }

        #endregion SetUp / TearDown

        #region Connection

        [Test]
        public void GetContext_ContextOpen()
        {
            Assert.IsTrue(this._context.Database.Exists());
        }

        #endregion Connection

        #region Addition

        [Test]
        [TestCase("joebloggs", "abcd1234", "joe@test.org", true)]
        [TestCase("jackandjill", "abcd1234", "jj@test.org", true)]
        public void CreateUser_GetUserDetails_UserAdded(string username, string password, string email, bool added)
        {
            var user = new User()
                       {
                           Username = username,
                           Password = password,
                           Email = email,
                           DateCreated = DateTime.Now,
                           CreatedBy = 1
                       };
            this._context.Users.Add(user);
            this._context.SaveChanges();
        }

        [Test]
        [TestCase("Joe", "Bloggs", 1, true)]
        [TestCase("Jack", "Jill", 2, true)]
        public void CreateMember_GetMemberDetails_MemberAdded(string givenNames, string surname, int userId, bool added)
        {
            var user = this._context.Users.Single(p => p.UserId == userId);

            var member = new Member()
                         {
                             GivenNames = givenNames,
                             Surname = surname,
                             DateCreated = DateTime.Now,
                             CreatedBy = 1,
                             User = user
                         };
            this._context.Members.Add(member);
            this._context.SaveChanges();
        }

        #endregion Addition
    }
}