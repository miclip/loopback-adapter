using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Globalization;
using Microsoft.ServiceModel.Channels.Common;

namespace LoopbackAdapter
{
    public class LoopbackAdapterBindingElement : StandardBindingElement
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LoopbackAdapterBindingElement class
        /// </summary>
        public LoopbackAdapterBindingElement()
            : base(null)
        {
        }


        /// <summary>
        /// Initializes a new instance of the LoopbackAdapterBindingElement class with a configuration name
        /// </summary>
        public LoopbackAdapterBindingElement(string configurationName)
            : base(configurationName)
        {
        }

        #endregion Constructors

        #region Protected Properties

        /// <summary>
        /// Gets the type of the BindingElement
        /// </summary>
        protected override Type BindingElementType
        {
            get
            {
                return typeof(LoopbackAdapterBinding);
            }
        }

        #endregion Protected Properties

        #region StandardBindingElement Members

        // Initializes the binding with the configuration properties
        protected override void InitializeFrom(Binding baseBinding)
        {
            base.InitializeFrom(baseBinding);
            LoopbackAdapterBinding binding = (LoopbackAdapterBinding)baseBinding;
            this[LoopbackAdapterConfigurationStrings.PreserveProperties] = binding.PreserveProperties;
        }

        // Applies the configuration
        protected override void OnApplyConfiguration(Binding baseBinding)
        {
            if (baseBinding == null)
            {
                throw new ArgumentNullException("binding");
            }

            LoopbackAdapterBinding binding = (LoopbackAdapterBinding)baseBinding;
            binding.PreserveProperties = (bool)this[LoopbackAdapterConfigurationStrings.PreserveProperties];

        }

        // Returns a collection of the configuration properties
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(LoopbackAdapterConfigurationStrings.PreserveProperties, typeof(bool), LoopbackAdapterConfigurationDefaults.DefaultPreserveProperties, null, null, ConfigurationPropertyOptions.None));
                return properties;
            }
        }

        #endregion StandardBindingElement Members

        #region Adapter Custom Configuration Properties

        [ConfigurationProperty(LoopbackAdapterConfigurationStrings.PreserveProperties, DefaultValue = LoopbackAdapterConfigurationDefaults.DefaultPreserveProperties)]
        [System.ComponentModel.Category("Adapter Properties")]
        public bool PreserveProperties
        {
            get
            {
                return ((bool)(base[LoopbackAdapterConfigurationStrings.PreserveProperties]));
            }
            set
            {
                base[LoopbackAdapterConfigurationStrings.PreserveProperties] = value;
            }
        }

        #endregion Adapter Custom Configuration Properties
    }
}
