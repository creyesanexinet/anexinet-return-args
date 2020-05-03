using System;
using System.Collections.Generic;
using AnexinetReturnArgs.Enums;

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
        /// <param name="userId">User unique identifier</param>
        /// <param name="eventName">Event name</param>
        /// <param name="screenName">Screen name</param>
        /// <param name="actionType">Action type</param>
        /// <param name="actionName">Action name</param>
        /// <param name="logData">Log data</param>
        /// <param name="exception">Exception</param>
        /// <param name="endLogging">End logging</param>
        void TraceWithFirebase(string userId = "", string eventName = "", string screenName = "", string actionType = "",
            string actionName = "", IDictionary<string, string> logData = null, Exception exception = null, bool endLogging = false);

        /// <summary>
        /// Trace with Microsoft App Center
        /// </summary>
        /// <param name="userId">User unique identifier</param>
        /// <param name="eventName">Event name</param>
        /// <param name="screenName">Screen name</param>
        /// <param name="actionType">Action type</param>
        /// <param name="actionName">Action name</param>
        /// <param name="logData">Log data</param>
        /// <param name="exception">Exception</param>
        /// <param name="endLogging">End logging</param>
        void TraceWithMSAppCenter(string userId = "", string eventName = "", string screenName = "", string actionType = "",
            string actionName = "", IDictionary<string, string> logData = null, Exception exception = null, bool endLogging = false);

        /// <summary>
        /// Trace with Amazon PinPoint
        /// </summary>
        /// <param name="userId">User unique identifier</param>
        /// <param name="eventName">Event name</param>
        /// <param name="screenName">Screen name</param>
        /// <param name="actionType">Action type</param>
        /// <param name="actionName">Action name</param>
        /// <param name="logData">Log data</param>
        /// <param name="exception">Exception</param>
        /// <param name="endLogging">End logging</param>
        void TraceWithAmazonPinpoint(string userId = "", string eventName = "", string screenName = "", string actionType = "",
            string actionName = "", IDictionary<string, string> logData = null, Exception exception = null, bool endLogging = false);
    }
}
