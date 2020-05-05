using System;
using System.Collections.Generic;

namespace AnexinetReturnArgs.Models
{
    /// <summary>
    /// Return arguments tracing model
    /// </summary>
    public class ReturnArgumentsTracingModel
    {
        /// <summary>
        /// Return arguments tracing model
        /// </summary>
        public ReturnArgumentsTracingModel()
        {
            UserId = "";
            EventName = "";
            ScreenName = "";
            ActionType = "";
            ActionName = "";
            LogData = null;
            Exception = null;
            EndLogging = false;
        }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Event name
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Screen name
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Action type
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Action name
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Log data
        /// </summary>
        public IDictionary< string, string> LogData { get; set; }

        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// End logging
        /// </summary>
        public bool EndLogging { get; set; }
    }
}
