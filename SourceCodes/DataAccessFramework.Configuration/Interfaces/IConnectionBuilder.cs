using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace DataAccessFramework.Configuration.Interfaces
{
    /// <summary>
    /// This provides interfaces to the ConnectionBuilder class.
    /// </summary>
    public interface IConnectionBuilder : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the list of all connection strings.
        /// </summary>
        IDictionary<string, string> ConnectionStrings { get; }

        /// <summary>
        /// Gets the list of all SQL connection instances.
        /// </summary>
        IDictionary<string, SqlConnection> SqlConnections { get; }

        /// <summary>
        /// Gets the list of all entity connection instances.
        /// </summary>
        IDictionary<string, EntityConnection> EntityConnections { get; }

        #endregion Properties

        #region Methods - ConnectionString

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        /// <param name="index">Index of the connection details.</param>
        /// <returns>Returns the database connection string.</returns>
        string GetConnectionString(int index);

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        /// <param name="key">Key to identify the connection details.</param>
        /// <returns>Returns the database connection string.</returns>
        string GetConnectionString(string key);

        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        /// <param name="connectionDetails">Connection details.</param>
        /// <returns>Returns the database connection string.</returns>
        string GetConnectionString(ConnectionDetailsElement connectionDetails);

        #endregion Methods - ConnectionString

        #region Methods - SqlConnection

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="index">Index of the connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        SqlConnection GetSqlConnection(int index);

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="key">Key to identify the connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        SqlConnection GetSqlConnection(string key);

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="connectionDetails">Connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        SqlConnection GetSqlConnection(ConnectionDetailsElement connectionDetails);

        #endregion Methods - SqlConnection

        #region Methods - EntityConnection

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="index">Index of the connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        EntityConnection GetEntityConnection(int index);

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="key">Key to identify the connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        EntityConnection GetEntityConnection(string key);

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <param name="connectionDetails">Connection details.</param>
        /// <returns>Returns the SQL connection.</returns>
        EntityConnection GetEntityConnection(ConnectionDetailsElement connectionDetails);

        #endregion Methods - EntityConnection
    }
}