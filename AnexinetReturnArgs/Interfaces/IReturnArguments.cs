using System;
using System.Collections.Generic;
using AnexinetReturnArgs.Enums;
using AnexinetReturnArgs.Models;

namespace AnexinetReturnArgs.Interfaces
{
    public interface IReturnArguments
    {
        /// <summary>
        /// Message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Value arguments
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Trace with firebase
        /// </summary>
        /// <param name="returnArgumentsTracingModel">Return arguments tracing model</param>
        void TraceWithFirebase(ReturnArgumentsTracingModel returnArgumentsTracingModel);

        /// <summary>
        /// Trace with Microsoft App Center
        /// </summary>
        /// <param name="returnArgumentsTracingModel">Return arguments tracing model</param>
        void TraceWithMSAppCenter(ReturnArgumentsTracingModel returnArgumentsTracingModel);

        /// <summary>
        /// Trace with Amazon PinPoint
        /// </summary>
        /// <param name="returnArgumentsTracingModel">Return arguments tracing model</param>
        void TraceWithAmazonPinpoint(ReturnArgumentsTracingModel returnArgumentsTracingModel);
    }
}
