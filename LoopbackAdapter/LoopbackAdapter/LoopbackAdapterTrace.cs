using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ServiceModel.Channels.Common;

namespace LoopbackAdapter
{
    // Use LoopbackAdapterUtilities.Trace in the code to trace the adapter
    public class LoopbackAdapterUtilities
    {
        static AdapterTrace _trace;

        static LoopbackAdapterUtilities()
        {
            //
            // Initializes a new instance of  Microsoft.ServiceModel.Channels.Common.AdapterTrace using the specified name for the source
            //
            _trace = new AdapterTrace("LoopbackAdapter");
        }

        /// <summary>
        /// Gets the AdapterTrace
        /// </summary>
        public static AdapterTrace Trace
        {
            get
            {
                return _trace;
            }
        }

    }


}

