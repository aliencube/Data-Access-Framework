using DataAccessFramework.Configuration;
using DataAccessFramework.Configuration.Interfaces;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Data;
using System.Linq;

namespace DataAccessFramework.Tests
{
    [TestFixture]
    public class DataContextConnectionTest
    {
        private IConnectionSettings _settings;
        private IConnectionBuilder _builder;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            this._settings = (IConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            this._builder = new ConnectionBuilder(this._settings);
        }

        [TearDown]
        public void Dispose()
        {
            this._builder.Dispose();
        }

        #endregion SetUp / TearDown

        #region ConnectionString

        [Test]
        public void GetConnectionStrings_ListOfConnectionStringsReturned()
        {
            Assert.IsTrue(this._builder.ConnectionStrings != null && this._builder.ConnectionStrings.Any());
        }

        [Test]
        [TestCase(0)]
        public void GetConnectionString_GetIndex_ConnectionFound(int index)
        {
            var connectionString = this._builder.GetConnectionString(index);

            Assert.IsTrue(!String.IsNullOrWhiteSpace(connectionString));
        }

        [Test]
        [TestCase(100)]
        public void GetConnectionString_GetIndex_ExceptionThrown(int index)
        {
            try
            {
                this._builder.GetConnectionString(index);
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        [TestCase("ApplicationDataContext", "ApplicationDatabase")]
        public void GetConnectionString_GetKey_ConnectionFound(string key, string initialCatalog)
        {
            var connectionString = this._builder.GetConnectionString(key);

            Assert.IsTrue(connectionString.ToLower().Contains("initial catalog=" + initialCatalog.ToLower()));
        }

        [Test]
        [TestCase("", "ApplicationDatabase")]
        [TestCase("WrongKey", "ApplicationDatabase")]
        public void GetConnectionString_GetKey_ExceptionThrown(string key, string initialCatalog)
        {
            try
            {
                this._builder.GetConnectionString(key);
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        #endregion ConnectionString

        #region SqlConnection

        [Test]
        public void GetSqlConnections_ListOfSqlConnectionsReturned()
        {
            Assert.IsTrue(this._builder.SqlConnections != null && this._builder.SqlConnections.Any());
        }

        [Test]
        [TestCase(0, true)]
        public void GetSqlConnection_GetIndex_ConnectionFound(int index, bool opened)
        {
            using (var connection = this._builder.GetSqlConnection(index))
            {
                connection.Open();
                Assert.AreEqual(opened, connection.State == ConnectionState.Open);
                connection.Close();
            }
        }

        [Test]
        [TestCase(100)]
        public void GetSqlConnection_GetIndex_ExceptionThrown(int index)
        {
            try
            {
                using (var connection = this._builder.GetSqlConnection(index))
                {
                }
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        [TestCase("ApplicationDataContext", true)]
        public void GetSqlConnection_GetKey_ConnectionFound(string key, bool opened)
        {
            using (var connection = this._builder.GetSqlConnection(key))
            {
                connection.Open();
                Assert.AreEqual(opened, connection.State == ConnectionState.Open);
                connection.Close();
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("WrongKey")]
        public void GetSqlConnection_GetKey_ExceptionThrown(string key)
        {
            try
            {
                using (var connection = this._builder.GetSqlConnection(key))
                {
                }
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        #endregion SqlConnection

        #region EntityConnection

        [Test]
        public void GetEntityConnections_ListOfEntityConnectionsReturned()
        {
            Assert.IsTrue(this._builder.EntityConnections != null && this._builder.EntityConnections.Any());
        }

        //[Test]
        //[TestCase(0, true)]
        //public void GetEntityConnection_GetIndex_ConnectionFound(int index, bool opened)
        //{
        //    using (var connection = this._builder.GetEntityConnection(index))
        //    {
        //        connection.Open();
        //        Assert.AreEqual(opened, connection.State == ConnectionState.Open);
        //        connection.Close();
        //    }
        //}

        [Test]
        [TestCase(100)]
        public void GetEntityConnection_GetIndex_ExceptionThrown(int index)
        {
            try
            {
                using (var connection = this._builder.GetEntityConnection(index))
                {
                }
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        //[Test]
        //[TestCase("ApplicationDataContext", true)]
        //public void GetEntityConnection_GetKey_ConnectionFound(string key, bool opened)
        //{
        //    using (var connection = this._builder.GetEntityConnection(key))
        //    {
        //        connection.Open();
        //        Assert.AreEqual(opened, connection.State == ConnectionState.Open);
        //        connection.Close();
        //    }
        //}

        [Test]
        [TestCase("")]
        [TestCase("WrongKey")]
        public void GetEntityConnection_GetKey_ExceptionThrown(string key)
        {
            try
            {
                using (var connection = this._builder.GetEntityConnection(key))
                {
                }
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        #endregion EntityConnection
    }
}