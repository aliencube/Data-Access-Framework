using DataAccessFramework.Configuration.Interfaces;
using System.Configuration;

namespace DataAccessFramework.Configuration
{
    /// <summary>
    /// This represents the connection settings configuration element.
    /// </summary>
    public class ConnectionSettings : ConfigurationSection, IConnectionSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the collection of connection details.
        /// </summary>
        [ConfigurationProperty("connectionDetails", IsRequired = true)]
        [ConfigurationCollection(typeof(ConnectionDetailsElementCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public ConnectionDetailsElementCollection ConnectionDetails
        {
            get { return (ConnectionDetailsElementCollection)this["connectionDetails"]; }
            set { this["connectionDetails"] = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion Methods
    }
}