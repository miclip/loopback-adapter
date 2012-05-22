using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

using Microsoft.ServiceModel.Channels.Common;


namespace LoopbackAdapter
{
    public class LoopbackAdapter:Adapter
    {
        // Scheme associated with the adapter
        internal const string SCHEME = "loopback";
        // Namespace for the proxy that will be generated from the adapter schema
        internal const string SERVICENAMESPACE = "loopback://LoopbackAdapter";
        // Adapter environment settings
        private static AdapterEnvironmentSettings _environmentSettings = new AdapterEnvironmentSettings();

        #region Custom Generated Fields

        private bool _preserveProperties;
        
        #endregion Custom Generated Fields

        #region  Constructor

         /// <summary>
        /// Initializes a new instance of the LoopbackAdapter class
        /// </summary>
        public LoopbackAdapter()
            : base(_environmentSettings)
        {
            // adapter settings
            this.Settings.Metadata.GenerateWsdlDocumentation = true;
        }

        public LoopbackAdapter(LoopbackAdapter binding)
            : base(binding)
        {
            this.PreserveProperties = binding.PreserveProperties;
            // adapter settings
            this.Settings.Metadata.GenerateWsdlDocumentation = true;
        }

        #endregion Constructor

        #region Custom Generated Properties

        [System.Configuration.ConfigurationProperty(LoopbackAdapterConfigurationStrings.PreserveProperties, DefaultValue = LoopbackAdapterConfigurationDefaults.DefaultPreserveProperties)]
        public bool PreserveProperties
        {
            get
            {
                return this._preserveProperties;
            }
            set
            {
                this._preserveProperties = value;
            }
        }

        #endregion Custom Generated Properties

        #region Public Properties

        /// <summary>
        /// Gets the URI transport scheme that is used by the adapter
        /// </summary>
        public override string Scheme
        {
            get
            {
                return SCHEME;
            }
        }

        public string ServiceNamespace
        {
            get
            {
                return SERVICENAMESPACE;
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Creates a ConnectionUri instance from the provided Uri
        /// </summary>
        protected override ConnectionUri BuildConnectionUri(Uri uri)
        {
            return new LoopbackAdapterConnectionUri(uri);
        }

        /// <summary>
        /// Builds a connection factory from the ConnectionUri and ClientCredentials
        /// </summary>
        /// <param name="target">The target Uri for the connection factory</param>
        /// <param name="credentialsManager">The credentials manager to be used by the connection factory</param>
        /// <returns>A connection factory object</returns>
        protected override IConnectionFactory BuildConnectionFactory(
            ConnectionUri unifiedConnectionUri
            , ClientCredentials clientCredentials
            , BindingContext context)
        {
            return new LoopbackAdapterConnectionFactory(unifiedConnectionUri, clientCredentials, this);
        }

        /// <summary>
        /// Returns a clone of the adapter object
        /// </summary>
        /// <returns>A clone of the adapter object</returns>
        protected override Adapter CloneAdapter()
        {
            return new LoopbackAdapter(this);
        }

        /// <summary>
        /// Indicates whether the provided TConnectionHandler is supported by the adapter or not
        /// </summary>
        /// <typeparam name="TConnectionHandler">IConnectionHandler type</typeparam>
        /// <returns>A Boolean indicating whether the provided TConnectionHandler is supported by the adapter or not</returns>
        protected override bool IsHandlerSupported<TConnectionHandler>()
        {
            return (typeof(IOutboundHandler) == typeof(TConnectionHandler));
        }

        /// <summary>
        /// Gets the namespace that is used when generating schema and WSDL
        /// </summary>
        protected override string Namespace
        {
            get
            {
                return SERVICENAMESPACE;
            }
        }

        #endregion Protected Methods

    }
}
