using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

namespace LoopbackAdapter
{
    /// <summary>
    /// This class is provided to surface Adapter as a binding element, so that it 
    /// can be used within a user-defined WCF "Custom Binding".
    /// 
    /// In configuration file, it is defined under
    /// <system.serviceModel>
    ///     <extensions>
    ///         <bindingElementExtensions>
    ///             <add name="{name}" type="{this}, {assembly}"/>
    ///         </bindingElementExtensions>
    ///     </extensions>
    /// </system.serviceModel>
    /// 
    /// </summary>
    public class LoopbackAdapterBindingElementExtension : BindingElementExtensionElement
    {
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


        /// <summary>
        /// Default constructor
        /// </summary>
        public LoopbackAdapterBindingElementExtension()
        {
        }

        #region Overriden Base Class Methods
        /// <summary>
        /// Return the type of the adapter (binding element)
        /// </summary>
        public override Type BindingElementType
        {
            get
            {
                return typeof(LoopbackAdapter);
            }
        }
        /// <summary>
        /// Return all the properites defined in this class.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(LoopbackAdapterConfigurationStrings.PreserveProperties, typeof(int), LoopbackAdapterConfigurationDefaults.DefaultPreserveProperties));
                return properties;
            }
        }

        /// <summary>
        /// Instantiate the adapter.
        /// </summary>
        /// <returns></returns>
        protected override BindingElement CreateBindingElement()
        {
            LoopbackAdapter adapter = new LoopbackAdapter();
            this.ApplyConfiguration(adapter);
            return adapter;
        }

        /// <summary>
        /// Pass the properties from configuration file to the adapter.
        /// </summary>
        /// <param name="bindingElement"></param>
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            base.ApplyConfiguration(bindingElement);
            LoopbackAdapter adapter = ((LoopbackAdapter)(bindingElement));
            adapter.PreserveProperties = this.PreserveProperties;

        }

        /// <summary>
        /// Initialize the binding properties from the adapter.
        /// </summary>
        /// <param name="bindingElement"></param>
        protected override void InitializeFrom(BindingElement bindingElement)
        {
            base.InitializeFrom(bindingElement);
            LoopbackAdapter adapter = ((LoopbackAdapter)(bindingElement));
            this.PreserveProperties = adapter.PreserveProperties;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        public override void CopyFrom(ServiceModelExtensionElement from)
        {
            base.CopyFrom(from);
            LoopbackAdapterBindingElementExtension source = ((LoopbackAdapterBindingElementExtension)(from));
            this.PreserveProperties = source.PreserveProperties;
        }

        #endregion Overriden Base Class Methods
    }

    /// <summary>
    /// Configuration strings for the binding properties
    /// </summary>
    public class LoopbackAdapterConfigurationStrings
    {
        internal const string PreserveProperties = "preserveProperties";
    }

    /// <summary>
    /// Provide defaults for the custom binding properties over here.
    /// </summary>
    public class LoopbackAdapterConfigurationDefaults
    {
        internal const bool DefaultPreserveProperties = false;
    }
}
