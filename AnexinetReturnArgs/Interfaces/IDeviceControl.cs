using System;
namespace AnexinetReturnArgs.Interfaces
{
    public interface IDeviceControl
    {
        string GetDeviceId();
        string DeviceSerialNumber();

        string DeviceModel();
        string DeviceManufacturer();
        string DeviceSerial();
        string DeviceBrand();
    }
}
