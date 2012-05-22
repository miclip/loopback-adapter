using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Microsoft.ServiceModel.Channels.Common;

namespace LoopbackAdapter
{
    /// <summary>
    /// Initializes a new instance of the LoopbackAdapterBindingCollectionElement class
    /// </summary>
    public class LoopbackAdapterBindingCollectionElement : StandardBindingCollectionElement<LoopbackAdapterBinding,
        LoopbackAdapterBindingElement>
    {
    }
}

