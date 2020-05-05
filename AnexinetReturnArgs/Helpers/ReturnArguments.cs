using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AnexinetReturnArgs.Enums;
using AnexinetReturnArgs.Interfaces;
using AnexinetReturnArgs.Models;
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
        /// <param name="returnArgumentsTracingModel">Return arguments tracing model</param>
        public void TraceWithFirebase(ReturnArgumentsTracingModel returnArgumentsTracingModel)
        {
            firebaseService = DependencyService.Get<IFirebaseService>();

            firebaseService.SetUserId(returnArgumentsTracingModel.UserId);
            firebaseService.ReportHandledException(returnArgumentsTracingModel.Exception);
            firebaseService.ReportUnHandledException(returnArgumentsTracingModel.Exception);
            firebaseService.LogEvent(returnArgumentsTracingModel.EventName);
            firebaseService.SetCurrentScreen(returnArgumentsTracingModel.ScreenName);
            firebaseService.LogActivity(Message, returnArgumentsTracingModel.EndLogging);

            if (returnArgumentsTracingModel.LogData != null && returnArgumentsTracingModel.LogData.Count > 0)
            {
                foreach (var parameter in returnArgumentsTracingModel.LogData)
                {
                    firebaseService.SetLogData(parameter.Key, parameter.Value);
                }
            }

            if (returnArgumentsTracingModel.Exception != null)
            {
                // TODO: Localization
                DependencyService.Get<IAlertManager>()
                    .ShowAlert(returnArgumentsTracingModel.Exception.Message,
                                "Error",
                                "OK");
            }
        }

        /// <summary>
        /// Trace with Microsoft App Center
        /// </summary>
        /// <param name="returnArgumentsTracingModel">Return arguments tracing model</param>
        public void TraceWithMSAppCenter(ReturnArgumentsTracingModel returnArgumentsTracingModel)
        {
            // TODO: add logging logic
        }

        /// <summary>
        /// Trace with Amazon PinPoint
        /// </summary>
        /// <param name="returnArgumentsTracingModel">Return arguments tracing model</param>
        public void TraceWithAmazonPinpoint(ReturnArgumentsTracingModel returnArgumentsTracingModel)
        {
            // TODO: add logging logic
        }
    }
}
