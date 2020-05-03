using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using AnexinetReturnArgs.Droid.DependencyService;
using AnexinetReturnArgs.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AlertManager))]
namespace AnexinetReturnArgs.Droid.DependencyService
{
    /// <summary>
    /// Alert manager.
    /// </summary>
    public class AlertManager : IAlertManager
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
        public void ShowAlert(string message, string title = "", string ActionTitle = "", string ActionTitleCancel = "", Action CallBackAction = null, Action CallBackNegativeAction = null, string EntryPlaceHolder = "", Action<string> CallBackEntryAction = null, Enums.CapitalizationType CapitalizationType = Enums.CapitalizationType.None, bool messageHasHtml = false)
        {
            MainActivity.Instance.RunOnUiThread(delegate
            {
                // Set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.Instance);

                EditText editText = null;

                if (!string.IsNullOrEmpty(EntryPlaceHolder))
                {
                    editText = new EditText(MainActivity.Instance) { Hint = EntryPlaceHolder };

                    if (CapitalizationType != Enums.CapitalizationType.None)
                    {
                        editText.InputType = Android.Text.InputTypes.TextFlagCapCharacters;
                    }

                    alert.SetView(editText);
                }


                if (!string.IsNullOrEmpty(title))
                {
                    alert.SetTitle(title);
                }

                alert.SetMessage(message);
                
                if (!string.IsNullOrEmpty(ActionTitle) && !string.IsNullOrEmpty(ActionTitleCancel))
                {
                    alert.SetPositiveButton(ActionTitle, (senderAlert, args) =>
                    {
                        CallBackAction?.Invoke();

                        if (editText != null && !string.IsNullOrEmpty(editText.Text))
                        {
                            CallBackEntryAction?.Invoke(editText.Text);
                        }
                        else
                        {
                            CallBackEntryAction?.Invoke(string.Empty);
                        }
                    });

                    alert.SetNegativeButton(ActionTitleCancel, (senderAlert, args) =>
                    {
                        CallBackNegativeAction?.Invoke();
                    });
                }
                else if (string.IsNullOrEmpty(ActionTitleCancel) && CallBackAction != null && CallBackNegativeAction != null)
                {
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {
                        CallBackAction?.Invoke();

                        if (editText != null && !string.IsNullOrEmpty(editText.Text))
                        {
                            CallBackEntryAction?.Invoke(editText.Text);
                        }
                    });

                    alert.SetNegativeButton(ActionTitleCancel, (senderAlert, args) =>
                    {
                        CallBackNegativeAction?.Invoke();
                    });
                }
                else if (string.IsNullOrEmpty(ActionTitle) && CallBackAction != null)
                {
                    alert.SetPositiveButton(ActionTitle, (senderAlert, args) =>
                    {
                        CallBackAction?.Invoke();

                        if (editText != null && !string.IsNullOrEmpty(editText.Text))
                        {
                            CallBackEntryAction?.Invoke(editText.Text);
                        }
                    });
                }
                else
                {
                    // TODO: localization
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {
                        CallBackAction?.Invoke();

                        if (editText != null && !string.IsNullOrEmpty(editText.Text))
                        {
                            CallBackEntryAction?.Invoke(editText.Text);
                        }
                    });
                }

                //This disable the back button when the alert is displayed
                alert.SetCancelable(false);

                alert.Show();
            });
        }

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
        public void ShowAlert(string message, string title, string ActionTitle, string ActionTitleNeutral, string ActionTitleCancel, Action CallBackAction = null, Action CallBackNeutralAction = null, Action CallBackNegativeAction = null, bool messageHasHtml = false)
        {
            MainActivity.Instance.RunOnUiThread(delegate
            {
                // Set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.Instance);

                EditText editText = null;

                alert.SetTitle(title);

                alert.SetMessage(message);
                
                alert.SetPositiveButton(ActionTitle, (senderAlert, args) =>
                {
                    CallBackAction?.Invoke();
                });

                alert.SetNeutralButton(ActionTitleNeutral, (senderAlert, args) =>
                {
                    CallBackNeutralAction?.Invoke();
                });

                alert.SetNegativeButton(ActionTitleCancel, (senderAlert, args) =>
                {
                    CallBackNegativeAction?.Invoke();
                });

                //This disable the back button when the alert is displayed
                alert.SetCancelable(false);

                alert.Show();
            });
        }

        /// <summary>
        /// Shows the alert async
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="title">Title.</param>
        /// <param name="ActionTitle">Action title.</param>
        /// <param name="ActionTitleCancel">Action title cancel.</param>
        /// <returns>True if the user choose action title; otherwise false</returns>
        public Task<bool> ShowAlertAsync(string message, string title = "", string ActionTitle = "", string ActionTitleCancel = "")
        {
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            MainActivity.Instance.RunOnUiThread(delegate
            {
                // Set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(MainActivity.Instance);

                if (!string.IsNullOrEmpty(title))
                {
                    alert.SetTitle(title);
                }

                alert.SetMessage(message);

                if (!string.IsNullOrEmpty(ActionTitle) && !string.IsNullOrEmpty(ActionTitleCancel))
                {
                    alert.SetPositiveButton(ActionTitle, (senderAlert, args) =>
                    {
                        taskCompletionSource.SetResult(true);
                    });

                    alert.SetNegativeButton(ActionTitleCancel, (senderAlert, args) =>
                    {
                        taskCompletionSource.SetResult(false);
                    });
                }
                else if (string.IsNullOrEmpty(ActionTitleCancel))
                {
                    // TODO: localization
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {
                        taskCompletionSource.SetResult(true);
                    });

                    alert.SetNegativeButton(ActionTitleCancel, (senderAlert, args) =>
                    {
                        taskCompletionSource.SetResult(false);
                    });
                }

                //This disable the back button when the alert is displayed
                alert.SetCancelable(false);

                alert.Show();
            });

            return taskCompletionSource.Task;
        }
    }
}
