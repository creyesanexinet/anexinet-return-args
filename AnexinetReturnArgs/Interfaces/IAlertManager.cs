using System;
using System.Threading.Tasks;

namespace AnexinetReturnArgs.Interfaces
{
    /// <summary>
    /// Alert manager.
    /// </summary>
    public interface IAlertManager
    {
        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="title">Title.</param>
        /// <param name="ActionTitle">Action title.</param>
        /// <param name="ActionTitleCancel">Action title cancel.</param>
        /// <param name="CallBackAction">Call back action.</param>
        /// <param name="CallBackNegativeAction">Call back negative action.</param>
        /// <param name="EntryPlaceHolder">Entry place holder.</param>
        /// <param name="CallBackEntryAction">Call back entry action.</param>
        /// <param name="CapitalizationType">The capitalization type.</param>
        /// <param name="messageHasHtml">Message has html</param>
        void ShowAlert(string message, string title = "", string ActionTitle = "", string ActionTitleCancel = "", Action CallBackAction = null, Action CallBackNegativeAction = null, string EntryPlaceHolder = "", Action<string> CallBackEntryAction = null, Enums.CapitalizationType CapitalizationType = Enums.CapitalizationType.None, bool messageHasHtml = false);

        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="title">Title.</param>
        /// <param name="ActionTitle">Action title.</param>
        /// <param name="ActionTitleNeutral">Acton title neutral</param>
        /// <param name="ActionTitleCancel">Action title cancel.</param>
        /// <param name="CallBackAction">Call back action.</param>
        /// <param name="CallBackNeutralAction">Call back neutral action.</param>
        /// <param name="CallBackNegativeAction">Call back entry action.</param>
        /// <param name="messageHasHtml">Message has html</param>
        void ShowAlert(string message, string title, string ActionTitle, string ActionTitleNeutral, string ActionTitleCancel, Action CallBackAction = null, Action CallBackNeutralAction = null, Action CallBackNegativeAction = null, bool messageHasHtml = false);

        /// <summary>
        /// Shows the alert async
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="title">Title.</param>
        /// <param name="ActionTitle">Action title.</param>
        /// <param name="ActionTitleCancel">Action title cancel.</param>
        /// <returns>True if the user choose action title; otherwise false</returns>
        Task<bool> ShowAlertAsync(string message, string title = "", string ActionTitle = "", string ActionTitleCancel = "");
    }
}
