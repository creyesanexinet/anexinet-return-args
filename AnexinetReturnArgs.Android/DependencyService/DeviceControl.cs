using System;
using AnexinetReturnArgs.Droid.DependencyService;
using AnexinetReturnArgs.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceControl))]
namespace AnexinetReturnArgs.Droid.DependencyService
{
    /// <summary>
    /// Device Control class
    /// </summary>
    public class DeviceControl : IDeviceControl
    {
        /// <summary>
        /// Returns the Device Id
        /// </summary>
        /// <returns></returns>
        public string GetDeviceId()
        {
            //reference: https://medium.com/@ssaurel/how-to-retrieve-an-unique-id-to-identify-android-devices-6f99fd5369eb

            var result = Android.Provider.Settings.Secure.GetString(MainActivity.Instance.ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            return result;
        }

        /// <summary>
        /// Returns the Device Serial Number
        /// </summary>
        /// <returns></returns>
        public string DeviceSerialNumber()
        {
            try
            {
                return Android.OS.Build.Serial;
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// Returns the Device Model
        /// </summary>
        /// <returns></returns>
        public string DeviceModel()
        {
            try
            {
                return Android.OS.Build.Model;
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// Returns the Device Manufacturer
        /// </summary>
        /// <returns></returns>
        public string DeviceManufacturer()
        {
            try
            {
                return Android.OS.Build.Manufacturer;
            }
            catch
            {
                return "unknown";
            }
        }

        // <summary>
        /// Returns the Device Serial
        /// </summary>
        /// <returns></returns>
        public string DeviceSerial()
        {
            try
            {
                return Android.OS.Build.Serial;
            }
            catch
            {
                return "unknown";
            }
        }

        // <summary>
        /// Returns the Device Brand
        /// </summary>
        /// <returns></returns>
        public string DeviceBrand()
        {
            try
            {
                return Android.OS.Build.Brand;
            }
            catch
            {
                return "unknown";
            }

        }
    }
}

