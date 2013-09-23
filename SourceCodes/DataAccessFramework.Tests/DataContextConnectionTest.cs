using DataAccessFramework.Configuration;
using DataAccessFramework.Helpers;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessFramework.Tests
{
    [TestFixture]
    public class DataContextConnectionTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Dispose()
        {
        }

        #endregion SetUp / TearDown

        #region ConnectionString

        [Test]
        public void GetConnectionStrings_ListOfConnectionStringsReturned()
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);

            Assert.IsTrue(helper.ConnectionStrings != null && helper.ConnectionStrings.Any());
        }

        [Test]
        [TestCase(0)]
        public void GetConnectionString_GetIndex_ConnectionFound(int index)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            var connectionString = helper.GetConnectionString(index);

            Assert.IsTrue(!String.IsNullOrWhiteSpace(connectionString));
        }

        [Test]
        [TestCase(100)]
        public void GetConnectionString_GetIndex_ExceptionThrown(int index)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            try
            {
                helper.GetConnectionString(index);
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        [TestCase("SampleDataContext", "SampleDatabase")]
        public void GetConnectionString_GetKey_ConnectionFound(string key, string initialCatalog)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            var connectionString = helper.GetConnectionString(key);

            Assert.IsTrue(connectionString.ToLower().Contains("initial catalog=" + initialCatalog.ToLower()));
        }

        [Test]
        [TestCase("", "SampleDatabase")]
        [TestCase("WrongKey", "SampleDatabase")]
        public void GetConnectionString_GetKey_ExceptionThrown(string key, string initialCatalog)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            try
            {
                helper.GetConnectionString(key);
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
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);

            Assert.IsTrue(helper.SqlConnections != null && helper.SqlConnections.Any());

            foreach (var connection in helper.SqlConnections)
            {
                connection.Value.Dispose();
            }
        }

        [Test]
        [TestCase(0, true)]
        public void GetSqlConnection_GetIndex_ConnectionFound(int index, bool opened)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            using (var connection = helper.GetSqlConnection(index))
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
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            try
            {
                using (var connection = helper.GetSqlConnection(index))
                {
                }
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        [TestCase("SampleDataContext", true)]
        public void GetSqlConnection_GetKey_ConnectionFound(string key, bool opened)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            using (var connection = helper.GetSqlConnection(key))
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
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            try
            {
                using (var connection = helper.GetSqlConnection(key))
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
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);

            Assert.IsTrue(helper.EntityConnections != null && helper.EntityConnections.Any());

            foreach (var connection in helper.EntityConnections)
            {
                connection.Value.Dispose();
            }
        }

        [Test]
        [TestCase(0, true)]
        public void GetEntityConnection_GetIndex_ConnectionFound(int index, bool opened)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            using (var connection = helper.GetEntityConnection(index))
            {
                connection.Open();
                Assert.AreEqual(opened, connection.State == ConnectionState.Open);
                connection.Close();
            }
        }

        [Test]
        [TestCase(100)]
        public void GetEntityConnection_GetIndex_ExceptionThrown(int index)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            try
            {
                using (var connection = helper.GetEntityConnection(index))
                {
                }
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        [TestCase("SampleDataContext", true)]
        public void GetEntityConnection_GetKey_ConnectionFound(string key, bool opened)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            using (var connection = helper.GetEntityConnection(key))
            {
                connection.Open();
                Assert.AreEqual(opened, connection.State == ConnectionState.Open);
                connection.Close();
            }
        }

        [Test]
        [TestCase("")]
        [TestCase("WrongKey")]
        public void GetEntityConnection_GetKey_ExceptionThrown(string key)
        {
            var settings = (ConnectionSettings)ConfigurationManager.GetSection("connectionSettings");
            var helper = new ConnectionHelper(settings);
            try
            {
                using (var connection = helper.GetEntityConnection(key))
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