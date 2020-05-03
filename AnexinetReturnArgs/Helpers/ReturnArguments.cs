using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AnexinetReturnArgs.Enums;
using AnexinetReturnArgs.Interfaces;
using Xamarin.Forms;

namespace AnexinetReturnArgs.Helpers
{
    /// <summary>
    /// Return arguments
    /// </summary>
    public class ReturnArguments: IReturnArguments
    {
        /// <summary>
        /// Firebase service
        /// </summary>
        protected IFirebaseService firebaseService;

        /// <summary>
        /// Return arguments
        /// </summary>
        /// <param name="hasError">Has error</param>
        /// <param name="message">Message</param>
        /// <param name="value">Value</param>
        public ReturnArguments(string message = null, string value = null)
        {
            Message = message;
            Value = value;
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Value arguments
        /// </summary>
        public object Value { get; set; }

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
        public void TraceWithFirebase(string userId = "", string eventName = "", string screenName = "", string actionType = "",
            string actionName = "", IDictionary<string, string> logData = null, Exception exception = null, bool endLogging = false)
        {
            firebaseService = DependencyService.Get<IFirebaseService>();

            firebaseService.SetUserId(userId);
            firebaseService.ReportHandledException(exception);
            firebaseService.ReportUnHandledException(exception);
            firebaseService.LogEvent(eventName);
            firebaseService.SetCurrentScreen(screenName);
            firebaseService.LogActivity(Message, endLogging);

            if (logData != null && logData.Count > 0)
            {
                foreach (var parameter in logData)
                {
                    firebaseService.SetLogData(parameter.Key, parameter.Value);
                }
            }

            // TODO: Localization
            DependencyService.Get<IAlertManager>()
                .ShowAlert(exception.Message,
                            "Error",
                            "OK");
        }

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
        public void TraceWithMSAppCenter(string userId = "", string eventName = "", string screenName = "", string actionType = "",
            string actionName = "", IDictionary<string, string> logData = null, Exception exception = null, bool endLogging = false)
        {
            // TODO: add logging logic
        }

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
        public void TraceWithAmazonPinpoint(string userId = "", string eventName = "", string screenName = "", string actionType = "",
            string actionName = "", IDictionary<string, string> logData = null, Exception exception = null, bool endLogging = false)
        {
            // TODO: add logging logic
        }
    }
}
