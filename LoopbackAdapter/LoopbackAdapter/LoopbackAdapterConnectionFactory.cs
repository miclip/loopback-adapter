using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Selectors;
using System.ServiceModel.Description;
using Microsoft.ServiceModel.Channels.Common;

namespace LoopbackAdapter
{
    public class LoopbackAdapterConnectionFactory : IConnectionFactory
    {
        #region Private Fields

        // Stores the client credentials
        private ClientCredentials _clientCredentials;
        // Stores the adapter class
        private LoopbackAdapter _adapter;

        #endregion Private Fields

        /// <summary>
        /// Initializes a new instance of the LoopbackAdapterConnectionFactory class
        /// </summary>
        public LoopbackAdapterConnectionFactory(ConnectionUri connectionUri
            , ClientCredentials clientCredentials
            , LoopbackAdapter adapter)
        {
            this._clientCredentials = clientCredentials;
            this._adapter = adapter;
        }

        #region Public Properties

        /// <summary>
        /// Gets the adapter
        /// </summary>
        public LoopbackAdapter Adapter
        {
            get
            {
                return this._adapter;
            }
        }

        /// <summary>
        /// Returns the client credentials
        /// </summary>
        public ClientCredentials ClientCredentials
        {
            get
            {
                return this._clientCredentials;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Creates the connection to the target system
        /// </summary>
        /// <returns>IConnection</returns>
        public IConnection CreateConnection()
        {
            return new LoopbackAdapterConnection(this);
        }

        #endregion Public Methods
    }
}
