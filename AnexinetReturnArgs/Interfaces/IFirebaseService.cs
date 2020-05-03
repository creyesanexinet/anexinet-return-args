using System;
using System.Collections.Generic;

namespace AnexinetReturnArgs.Interfaces
{
    /// <summary>
    /// Firebase service
    /// </summary>
    public interface IFirebaseService
    {
        void SetUserId(string userId);
        void ReportHandledException(Exception ex);
        void ReportUnHandledException(Exception ex);
        void SetLogData(string name, string value);
        void ClearLogData();
        void LogEvent(string eventName);
        void SetCurrentScreen(string screenName);
        void TrackUserAction(string actionType, string actionName, IDictionary<string, string> additionalParameters = null);
        void LogActivity(string message, bool endLogging = false);
    }
}
