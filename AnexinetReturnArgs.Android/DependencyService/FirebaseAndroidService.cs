using System;
using System.Collections.Generic;
using Android.OS;
using AnexinetReturnArgs.Droid;
using AnexinetReturnArgs.Droid.DependencyService;
using AnexinetReturnArgs.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(FirebaseAndroidService))]
namespace AnexinetReturnArgs.Droid.DependencyService
{
    public class FirebaseAndroidService : IFirebaseService
    {
        private Bundle _bundle = new Bundle();

        /// <summary>
        /// Clear Log Data
        /// </summary>
        public void ClearLogData()
        {
            _bundle.Clear();
        }

        /// <summary>
        /// Logs the Event
        /// </summary>
        /// <param name="eventName"></param>
        public void LogEvent(string eventName)
        {
            MainActivity.FirebaseAnalyticsInstance.LogEvent(eventName, _bundle);
            _bundle.Clear();
        }

        /// <summary>
        /// Logs the Activity
        /// </summary>
        /// <param name="message"></param>
        /// <param name="endLogging"></param>
        public void LogActivity(string message, bool endLogging = false)
        {
            SetLogData("message", message);
            LogEvent("log_activity");
        }

        /// <summary>
        /// Report Handled Exception
        /// </summary>
        /// <param name="ex"></param>
        public void ReportHandledException(Exception ex)
        {
            SetLogData("exception_type", "handled_exception");
            SetLogData("exception_message", ex.Message);
            LogEvent("mobile_exception");

            
        }

        /// <summary>
        /// Report UnHandled Exception
        /// </summary>
        /// <param name="ex"></param>
        public void ReportUnHandledException(Exception ex)
        {
            SetLogData("exception_type", "app_crash");
            SetLogData("exception_message", ex.Message);
            LogEvent("mobile_exception");
        }

        /// <summary>
        /// Set Current Screen
        /// </summary>
        /// <param name="screenName"></param>
        public void SetCurrentScreen(string screenName)
        {
            MainActivity.FirebaseAnalyticsInstance.SetCurrentScreen(MainActivity.Instance, screenName, null);
        }

        /// <summary>
        /// Set Log Data
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetLogData(string name, string value)
        {
            if (value == null)
            {
                return;
            }

            _bundle.PutString(name, value);
        }

        /// <summary>
        /// Set User Id
        /// </summary>
        /// <param name="userId"></param>
        public void SetUserId(string userId)
        {
            MainActivity.FirebaseAnalyticsInstance.SetUserId(userId);
        }

        /// <summary>
        /// Track User Action
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="actionName"></param>
        /// <param name="additionalParameters"></param>
        public void TrackUserAction(string actionType, string actionName, IDictionary<string, string> additionalParameters = null)
        {
            SetLogData("action_type", actionType.ToString());
            SetLogData("action_name", actionName.ToString());

            if (additionalParameters != null && additionalParameters.Count > 0)
            {
                foreach (var parameter in additionalParameters)
                {
                    SetLogData(parameter.Key, parameter.Value);
                }
            }

            LogEvent("user_action");
        }
    }
}

