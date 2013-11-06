using DataAccessFramework.Configuration;
using DataAccessFramework.Configuration.Interfaces;
using DataAccessFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessFramework.Helpers
{
    /// <summary>
    /// This helps to manage connections for data soruce.
    /// </summary>
    public class ConnectionHelper : IConnectionHelper
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the ConnectionHelper object.
        /// </summary>
        /// <param name="settings">Connection settings instance.</param>
        public ConnectionHelper(IConnectionSettings settings)
        {
            this._settings = settings;
        }

        #endregion Constructors

        #region Properties

        private readonly IConnectionSettings _settings;

        private IDictionary<string, string> _connectionStrings;

        /// <summary>
        /// Gets the list of all connection strings.
        /// </summary>
        public IDictionary<string, string> ConnectionStrings
        {
            get
            {
                if (this._connectionStrings == null || !this._connectionStrings.Any())
                    this._connectionStrings = this.GetAllConnectionStrings();
                return this._connectionStrings;
            }
        }

        private IDictionary<string, SqlConnection> _sqlConnections;

        /// <summary>
        /// Gets the list of all SQL connection instances.
        /// </summary>
        public IDictionary<string, SqlConnection> SqlConnections
        {
            get
            {
                if (this._sqlConnections == null || !this._sqlConnections.Any())
                    this._sqlConnections = this.GetAllSqlConnections();
                return this._sqlConnections;
            }
        }

        private IDictionary<string, EntityConnection> _entityConnections;

        /// <summary>
        /// Gets the list of all entity connection instances.
        /// </summary>
        public IDictionary<string, EntityConnection> EntityConnections
        {
            get
            {
                if (this._entityConnections == null || !this._entityConnections.Any())
                    this._entityConnections = this.GetAllEntityConnections();
                return this._entityConnections;
            }
        }

        #endregion Properties

        #region Methods - Private

        /// <summary>
        /// Gets the list of all conection strings identified.
        /// </summary>
        /// <returns>Returns the list of all connection strings identified.</returns>
        private IDictionary<string, string> GetAllConnectionStrings()
        {
            var connectionStrings = this._settings
                                        .ConnectionDetails
                                        .Cast<ConnectionDetailsElement>()
                                        .ToDictionary(p => p.Key, p => this.GetConnectionString(p.Key));
            return connectionStrings;
        }

        /// <summary>
        /// Gets the list of all SQL connections identified.
        /// </summary>
        /// <returns>Returns the list of all SQL connections identified.</returns>
        private IDictionary<string, SqlConnection> GetAllSqlConnections()
        {
            var connections = this._settings
                                  .ConnectionDetails
                                  .Cast<ConnectionDetailsElement>()
                                  .ToDictionary(p => p.Key, p => this.GetSqlConnection(p.Key));
            return connections;
        }

        /// <summary>
        /// Gets the list of all entity connections identified.
        /// </summary>
        /// <returns>Returns the list of all entity connections identified.</returns>
        private IDictionary<string, EntityConnection> GetAllEntityConnections()
        {
            var connections = this._settings
                                  .ConnectionDetails
                                  .Cast<ConnectionDetailsElement>()
                                  .ToDictionary(p => p.Key, p => this.GetEntityConnection(p.Key));
            return connections;
        }

        #endregion Methods - Private

        #region Methods - ConnectionString

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        /// <param name="index">Index of the connection details.</param>
        /// <returns>Returns the database connection string.</returns>
        public string GetConnectionString(int index)
        {
            if (index < 0 || index >= this._settings.ConnectionDetails.Count)
                throw new IndexOutOfRangeException("Index out of range");

            var settings = this._settings.ConnectionDetails[index];
            return this.GetConnectionString(settings);
        }

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        /// <param name="key">Key to identify the connection details.</param>
        /// <returns>Returns the database connection string.</returns>
        public string GetConnectionString(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key", "No key provided");

            var details = this._settings.ConnectionDetails[key];
            if (details == null)
                throw new ArgumentException("No connection details found");

            return this.GetConnectionString(details);
        }

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        /// <param name="connectionDetails">Connection details.</param>
        /// <returns>Returns the database connection string.</returns>
        public string GetConnectionString(ConnectionDetailsElement connectionDetails)
        {
            if (connectionDetails == null)
                throw new ArgumentNullException("connectionDetails", "No connection details provided");

            if (!connectionDetails.Use)
                throw new ArgumentException("Connection details no longer used");

            //  Gets the SQL connection string builder.
            var sqlBuilder = new SqlConnectionStringBuilder()
            {
                //  Advanced
                MultipleActiveResultSets = connectionDetails.MultipleActiveResultSets,
                //NetworkLibrary = connectionDetails.NetworkLibrary,
                PacketSize = connectionDetails.PacketSize,
                TransactionBinding = connectionDetails.TransactionBinding,
                TypeSystemVersion = connectionDetails.TypeSystemVersion,

                //  Context
                ApplicationName = connectionDetails.ApplicationName,
                WorkstationID = connectionDetails.WorkstationId,

                //  Initialisation
                //ApplicationIntent = connectionDetails.ApplicationIntent,
                AsynchronousProcessing = connectionDetails.AsynchronousProcessing,
                ConnectTimeout = connectionDetails.ConnectionTimeout,
                CurrentLanguage = connectionDetails.CurrentLanguage,

                //  Pooling
                Enlist = connectionDetails.Enlist,
                LoadBalanceTimeout = connectionDetails.LoadBalanceTimeout,
                MaxPoolSize = connectionDetails.MaxPoolSize,
                MinPoolSize = connectionDetails.MinPoolSize,
                Pooling = connectionDetails.Pooling,

                //  Replication
                Replication = connectionDetails.Replication,

                //  Security
                IntegratedSecurity = connectionDetails.IntegratedSecurity,
                Password = connectionDetails.IntegratedSecurity ? String.Empty : connectionDetails.Password,
                PersistSecurityInfo = connectionDetails.PersistSecurityInfo,
                TrustServerCertificate = connectionDetails.TrustServerCertificate,
                UserID = connectionDetails.IntegratedSecurity ? String.Empty : connectionDetails.UserId,

                //  Source
                AttachDBFilename = connectionDetails.AttachDbFilename,
                ContextConnection = connectionDetails.ContextConnection,
                DataSource = connectionDetails.DataSource,
                FailoverPartner = connectionDetails.FailoverPartner,
                InitialCatalog = connectionDetails.InitialCatalog,
                //MultiSubnetFailover = connectionDetails.MultiSubnetFailover,
                UserInstance = connectionDetails.UserInstance
            };
            var connectionString = sqlBuilder.ToString();

            //if (!String.IsNullOrWhiteSpace(connectionDetails.ApplicationIntent))
            //{
            //    if (!connectionString.EndsWith(";"))
            //        connectionString += ";";

            //    connectionString += String.Format("ApplicationIntent={0}", connectionDetails.ApplicationIntent);
            //}
            //connectionString += String.Format("MultiSubnetFailover={0}", connectionDetails.MultiSubnetFailover);

            return connectionString;
        }

        #endregion Methods - ConnectionString

        #region Methods - SqlConnection

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="index">Index of the connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        public SqlConnection GetSqlConnection(int index)
        {
            if (index < 0 || index >= this._settings.ConnectionDetails.Count)
                throw new IndexOutOfRangeException("Index out of range");

            var details = this._settings.ConnectionDetails[index];
            return this.GetSqlConnection(details);
        }

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="key">Key to identify the connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        public SqlConnection GetSqlConnection(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key", "No key provided");

            var details = this._settings.ConnectionDetails[key];
            return this.GetSqlConnection(details);
        }

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="connectionDetails">Connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        public SqlConnection GetSqlConnection(ConnectionDetailsElement connectionDetails)
        {
            //  Gets the SQL connection string.
            var connectionString = this.GetConnectionString(connectionDetails);

            return new SqlConnection(connectionString);
        }

        #endregion Methods - SqlConnection

        #region Methods - EntityConnection

        /// <summary>
        /// Gets the database connection through entity framework.
        /// </summary>
        /// <param name="index">Index of the connection details.</param>
        /// <returns>Returns the database connection through entity framework.</returns>
        public EntityConnection GetEntityConnection(int index)
        {
            if (index < 0 || index >= this._settings.ConnectionDetails.Count)
                throw new IndexOutOfRangeException("Index out of range");

            var details = this._settings.ConnectionDetails[index];
            return this.GetEntityConnection(details);
        }

        /// <summary>
        /// Gets the database connection through entity framework.
        /// </summary>
        /// <param name="key">Key to identify the connection details.</param>
        /// <returns>Returns the database connection through entity framework.</returns>
        public EntityConnection GetEntityConnection(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("key", "No key provided");

            var details = this._settings.ConnectionDetails[key];
            return this.GetEntityConnection(details);
        }

        /// <summary>
        /// Gets the database connection through entity framework.
        /// </summary>
        /// <param name="connectionDetails">Connection details.</param>
        /// <returns>Returns the database connection through entity framework.</returns>
        public EntityConnection GetEntityConnection(ConnectionDetailsElement connectionDetails)
        {
            //  Gets the SQL connection string builder.
            var connectionString = this.GetConnectionString(connectionDetails);

            //  Gets the entity framework connection string builder.
            var efBuilder = new EntityConnectionStringBuilder()
            {
                Provider = connectionDetails.Provider,
                ProviderConnectionString = connectionString,
                Metadata = String.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
                                         connectionDetails.DataContext)
            };

            return new EntityConnection(efBuilder.ToString());
        }

        #endregion Methods - EntityConnection

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.SqlConnections != null && this.SqlConnections.Any())
                foreach (var connection in this.SqlConnections
                                               .Where(p => p.Value.State == ConnectionState.Open)
                                               .Select(p => p.Value))
                {
                    connection.Close();
                }

            if (this.EntityConnections != null && this.EntityConnections.Any())
                foreach (var connection in this.EntityConnections
                                               .Where(p => p.Value.State == ConnectionState.Open)
                                               .Select(p => p.Value))
                {
                    connection.Close();
                }
        }
    }
}