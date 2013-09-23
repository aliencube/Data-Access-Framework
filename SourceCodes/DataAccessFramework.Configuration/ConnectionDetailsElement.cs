using System;
using System.Configuration;

namespace DataAccessFramework.Configuration
{
	/// <summary>
	/// This represents the connection details element entity.
	/// </summary>
	public class ConnectionDetailsElement : ConfigurationElement
	{
		#region General

		/// <summary>
		/// Gets or sets the database context name to be used in Entity Framework.
		/// Default value is <c>ApplicationDataContext</c>.
		/// </summary>
		[ConfigurationProperty("dataContext", DefaultValue = "ApplicationDataContext", IsRequired = false)]
		public string DataContext
		{
			get { return (string)this["dataContext"]; }
			set { this["dataContext"] = value; }
		}

		/// <summary>
		/// Gets or sets the unique key to identify the connection.
		/// </summary>
		[ConfigurationProperty("key", IsRequired = true)]
		public string Key
		{
			get { return (string)this["key"]; }
			set { this["key"] = value; }
		}

		/// <summary>
		/// Gets or sets the database provider.
		/// Default value is <see cref="System.Data.SqlClient" />.
		/// </summary>
		/// <remarks>It currently supports MS-SQL only. So the value must be <see cref="System.Data.SqlClient" />.</remarks>
		[ConfigurationProperty("provider", DefaultValue = "System.Data.SqlClient", IsRequired = false)]
		public string Provider
		{
			get { return (string)this["provider"]; }
			set { this["provider"] = value; }
		}

		/// <summary>
		/// Gets or sets the connection string type - Entity Framework or SQL connection.
		/// Default value is <c>EntityFramework</c>.
		/// </summary>
		/// <remarks>It currently support Entity Framework only. So the value must be <c>EntityFramework</c>.</remarks>
		[ConfigurationProperty("type", DefaultValue = "EntityFramework", IsRequired = false)]
		public string Type
		{
			get { return (string)this["type"]; }
			set { this["type"] = value; }
		}

		/// <summary>
		/// Gets or sets the value that specifies whether to use this connection or not.
		/// Default value is <c>True</c>.
		/// </summary>
		[ConfigurationProperty("use", DefaultValue = true, IsRequired = false)]
		public bool Use
		{
			get { return (bool)this["use"]; }
			set { this["use"] = value; }
		}

		#endregion General

		#region	Advanced

		/// <summary>
		/// Gets or sets a value that indicates whether multiple active result sets
		/// can be associated with the associated connection.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("multipleActiveResultSets", DefaultValue = false, IsRequired = false)]
		public bool MultipleActiveResultSets
		{
			get { return (bool)this["multipleActiveResultSets"]; }
			set { this["multipleActiveResultSets"] = value; }
		}

		/// <summary>
		/// Gets or sets a string that contains the name of the network library
		/// used to establish a connection to the SQL Server.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		[ConfigurationProperty("networkLibrary", DefaultValue = "", IsRequired = false)]
		public string NetworkLibrary
		{
			get { return (string)this["networkLibrary"]; }
			set { this["networkLibrary"] = value; }
		}

		/// <summary>
		/// Gets or sets the size in bytes of the network packets used to communicate with an instance of SQL Server.
		/// Default value is <c>8000</c>.
		/// </summary>
		[ConfigurationProperty("packetSize", DefaultValue = 8000, IsRequired = false)]
		public int PacketSize
		{
			get { return (int)this["packetSize"]; }
			set { this["packetSize"] = value; }
		}

		/// <summary>
		/// Gets or sets a string value that indicates how the connection maintains its
		/// association with an enlisted <see cref="System.Transactions"/> transaction.
		/// Default value is <c>Implicit Unbind</c>.
		/// </summary>
		[ConfigurationProperty("transactionBinding", DefaultValue = "Implicit Unbind", IsRequired = false)]
		public string TransactionBinding
		{
			get { return (string)this["transactionBinding"]; }
			set { this["transactionBinding"] = value; }
		}

		/// <summary>
		/// Gets or sets a string value that indicates the type system the application expects.
		/// Default value is <c>Latest</c>.
		/// </summary>
		[ConfigurationProperty("typeSystemVersion", DefaultValue = "Latest", IsRequired = false)]
		public string TypeSystemVersion
		{
			get { return (string)this["typeSystemVersion"]; }
			set { this["typeSystemVersion"] = value; }
		}

		#endregion

		#region	Context

		/// <summary>
		/// Gets or sets the name of the application associated with the connection string.
		/// Default value is <c>.NET SqlClient Data Provider</c>.
		/// </summary>
		[ConfigurationProperty("applicationName", DefaultValue = ".NET SqlClient Data Provider", IsRequired = false)]
		public string ApplicationName
		{
			get { return (string)this["applicationName"]; }
			set { this["applicationName"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the workstation connecting to SQL Server.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		/// <remarks>If <c>IntegratedSecurity</c> is set to <c>True</c>, this is not necessary.</remarks>
		[ConfigurationProperty("workstationId", DefaultValue = "", IsRequired = false)]
		public string WorkstationId
		{
			get { return (string)this["workstationId"]; }
			set { this["workstationId"] = value; }
		}

		#endregion

		#region	Initialisation

		/// <summary>
		/// Declares the application workload type
		/// when connecting to a database in an SQL Server Availability Group.
		/// Default value is <c>ReadWrite</c>.
		/// </summary>
		/// <remarks>Possible value is either <c>ReadWrite</c> or <c>ReadOnly</c>.</remarks>
		[ConfigurationProperty("applicationIntent", DefaultValue = "ReadWrite", IsRequired = false)]
		public string ApplicationIntent
		{
			get { return (string) this["applicationIntent"]; }
			set { this["applicationIntent"] = value; }
		}

		// applicationIntent

		/// <summary>
		/// Gets or sets a value that indicates whether asynchronous processing is allowed
		/// by the connection created by using this connection string or not.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("asynchronousProcessing", DefaultValue = false, IsRequired = false)]
		public bool AsynchronousProcessing
		{
			get { return (bool)this["asynchronousProcessing"]; }
			set { this["asynchronousProcessing"] = value; }
		}

		/// <summary>
		/// Gets or sets the length of time (in seconds) to wait for a connection to the server
		/// before terminating the attempt and generating an error.
		/// Default value is <c>15</c>.
		/// </summary>
		[ConfigurationProperty("connectionTimeout", DefaultValue = 15, IsRequired = false)]
		public int ConnectionTimeout
		{
			get { return (int)this["connectionTimeout"]; }
			set { this["connectionTimeout"] = value; }
		}

		/// <summary>
		/// Gets or sets the SQL Server Language record name.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		[ConfigurationProperty("currentLanguage", DefaultValue = "", IsRequired = false)]
		public string CurrentLanguage
		{
			get { return (string)this["currentLanguage"]; }
			set { this["currentLanguage"] = value; }
		}

		#endregion

		#region	Pooling

		/// <summary>
		/// Gets or sets a value that indicates whether the SQL Server connection pooler
		/// automatically enlists the connection in the creation thread's current transaction context.
		/// Default value is <c>True</c>.
		/// </summary>
		[ConfigurationProperty("enlist", DefaultValue = true, IsRequired = false)]
		public bool Enlist
		{
			get { return (bool)this["enlist"]; }
			set { this["enlist"] = value; }
		}

		/// <summary>
		/// Gets or sets the minimum time, in seconds, for the connection
		/// to live in the connection pool before being destroyed.
		/// Default value is <c>0</c>.
		/// </summary>
		[ConfigurationProperty("loadBalanceTimeout", DefaultValue = 0, IsRequired = false)]
		public int LoadBalanceTimeout
		{
			get { return (int)this["loadBalanceTimeout"]; }
			set { this["loadBalanceTimeout"] = value; }
		}

		/// <summary>
		/// Gets or sets the maximum number of connections allowed in the connection pool
		/// for this specific connection string.
		/// Default value is <c>100</c>.
		/// </summary>
		[ConfigurationProperty("maxPoolSize", DefaultValue = 100, IsRequired = false)]
		public int MaxPoolSize
		{
			get { return (int)this["maxPoolSize"]; }
			set { this["maxPoolSize"] = value; }
		}

		/// <summary>
		/// Gets or sets the minimum number of connections allowed in the connection pool
		/// for this specific connection string.
		/// Default value is <c>0</c>.
		/// </summary>
		[ConfigurationProperty("minPoolSize", DefaultValue = 0, IsRequired = false)]
		public int MinPoolSize
		{
			get { return (int)this["minPoolSize"]; }
			set { this["minPoolSize"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether the connection will be pooled
		/// or explicitly opened every time that the connection is requested.
		/// Default value is <c>True</c>.
		/// </summary>
		[ConfigurationProperty("pooling", DefaultValue = true, IsRequired = false)]
		public bool Pooling
		{
			get { return (bool)this["pooling"]; }
			set { this["pooling"] = value; }
		}

		#endregion

		#region	Replication

		/// <summary>
		/// Gets or sets a value that indicates whether replication is supported using the connection.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("replication", DefaultValue = false, IsRequired = false)]
		public bool Replication
		{
			get { return (bool)this["replication"]; }
			set { this["replication"] = value; }
		}

		#endregion

		#region	Security

		/// <summary>
		/// Gets or sets a value that indicates whether SQL Server uses SSL encryption
		/// for all data sent between the client and server if the server has a certificate installed.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("encrypt", DefaultValue = false, IsRequired = false)]
		public bool Encrypt
		{
			get { return (bool)this["encrypt"]; }
			set { this["encrypt"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether User ID and Password are specified
		/// in the connection (when false) or whether the current Windows account credentials
		/// are used for authentication (when true).
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("integratedSecurity", DefaultValue = false, IsRequired = false)]
		public bool IntegratedSecurity
		{
			get { return (bool)this["integratedSecurity"]; }
			set { this["integratedSecurity"] = value; }
		}

		/// <summary>
		/// Gets or sets the password for the SQL Server account.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		/// <remarks>If <c>IntegratedSecurity</c> is set to <c>True</c>, this is not necessary.</remarks>
		[ConfigurationProperty("password", DefaultValue = "", IsRequired = false)]
		public string Password
		{
			get { return (string)this["password"]; }
			set { this["password"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates if security-sensitive information,
		/// such as the password, is not returned as part of the connection if the connection
		/// is open or has ever been in an open state.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("persistSecurityInfo", DefaultValue = false, IsRequired = false)]
		public bool PersistSecurityInfo
		{
			get { return (bool)this["persistSecurityInfo"]; }
			set { this["persistSecurityInfo"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether the channel will be encrypted
		/// while bypassing walking the certificate chain to validate trust.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("trustServerCertificate", DefaultValue = false, IsRequired = false)]
		public bool TrustServerCertificate
		{
			get { return (bool)this["trustServerCertificate"]; }
			set { this["trustServerCertificate"] = value; }
		}

		/// <summary>
		/// Gets or sets the user ID to be used when connecting to SQL Server.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		/// <remarks>If <c>IntegratedSecurity</c> is set to <c>True</c>, this is not necessary.</remarks>
		[ConfigurationProperty("userId", DefaultValue = "", IsRequired = false)]
		public string UserId
		{
			get { return (string)this["userId"]; }
			set { this["userId"] = value; }
		}

		#endregion

		#region	Source

		/// <summary>
		/// Gets or sets a string that contains the name of the primary data file.
		/// This includes the full path name of an attachable database.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		[ConfigurationProperty("attachDbFilename", DefaultValue = "", IsRequired = false)]
		public string AttachDbFilename
		{
			get { return (string)this["attachDbFilename"]; }
			set { this["attachDbFilename"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether a client/server or in-process connection
		/// to SQL Server should be made.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("contextConnection", DefaultValue = false, IsRequired = false)]
		public bool ContextConnection
		{
			get { return (bool)this["contextConnection"]; }
			set { this["contextConnection"] = value; }
		}

		/// <summary>
		/// Gets or sets the name or network address of the instance of SQL Server to connect to.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		[ConfigurationProperty("dataSource", DefaultValue = "", IsRequired = false)]
		public string DataSource
		{
			get { return (string)this["dataSource"]; }
			set { this["dataSource"] = value; }
		}

		/// <summary>
		/// Gets or sets the name or address of the partner server to connect to
		/// if the primary server is down.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		[ConfigurationProperty("failoverPartner", DefaultValue = "", IsRequired = false)]
		public string FailoverPartner
		{
			get { return (string)this["failoverPartner"]; }
			set { this["failoverPartner"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the database associated with the connection.
		/// Default value is <see cref="String.Empty" />.
		/// </summary>
		[ConfigurationProperty("initialCatalog", DefaultValue = "", IsRequired = false)]
		public string InitialCatalog
		{
			get { return (string)this["initialCatalog"]; }
			set { this["initialCatalog"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether to provide faster detection of and
		/// connection to the (currently) active server.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("multiSubnetFailover", DefaultValue = false, IsRequired = false)]
		public bool MultiSubnetFailover
		{
			get { return (bool)this["multiSubnetFailover"]; }
			set { this["multiSubnetFailover"] = value; }
		}

		/// <summary>
		/// Gets or sets a value that indicates whether to redirect the connection
		/// from the default SQL Server Express instance to a runtime-initiated instance
		/// running under the account of the caller.
		/// Default value is <c>False</c>.
		/// </summary>
		[ConfigurationProperty("userInstance", DefaultValue = false, IsRequired = false)]
		public bool UserInstance
		{
			get { return (bool)this["userInstance"]; }
			set { this["userInstance"] = value; }
		}

		#endregion
	}
}