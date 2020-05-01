using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AnexinetReturnArgs.Helpers;
using AnexinetReturnArgs.Interfaces;
using Xamarin.Forms;

namespace AnexinetReturnArgs.ViewModels
{
    /// <summary>
    /// Base view model
    /// </summary>
    public class BaseViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Firebase service
        /// </summary>
        protected IFirebaseService firebaseService;

        /// <summary>
        /// Return arguments
        /// </summary>
        private IReturnArguments _returnArguments;

        /// <summary>
        /// Base view model
        /// </summary>
        protected BaseViewModel()
        {

        }

        /// <summary>
        /// Return argumensts
        /// </summary>
        public IReturnArguments ReturnArguments
        {
            get
            {
                if (_returnArguments == null)
                {
                    _returnArguments = new ReturnArguments();
                }
                return _returnArguments;
            }
            set
            {
                _returnArguments = value;
            }
        }

        /// <summary>
        /// Set Firebase Log Attributes
        /// </summary>
        private void SetFirebaseLogAttributes()
        {
            firebaseService = DependencyService.Get<IFirebaseService>();

            firebaseService.SetUserId("");

            var deviceControl = DependencyService.Get<IDeviceControl>();

            if (deviceControl != null)
            {
                firebaseService?.SetLogData(nameof(deviceControl.DeviceBrand), deviceControl.DeviceBrand());
                firebaseService?.SetLogData(nameof(deviceControl.DeviceManufacturer), deviceControl.DeviceManufacturer());
                firebaseService?.SetLogData(nameof(deviceControl.DeviceModel), deviceControl.DeviceSerial());
                firebaseService?.SetLogData(nameof(deviceControl.DeviceSerialNumber), deviceControl.DeviceSerialNumber());
            }
        }

        /// <summary>
        /// On appearing
        /// </summary>
        public virtual void OnAppearing()
        {
            SetFirebaseLogAttributes();
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to Bind ViewModel-View
        /// </summary>
        /// <param name="propertyName">Changed Property name.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
