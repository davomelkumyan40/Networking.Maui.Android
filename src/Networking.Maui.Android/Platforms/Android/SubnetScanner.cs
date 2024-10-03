using Com.Stealthcopter.Networktools;
using Networking.Maui.Android.AsyncEvents;
using Device = Networking.Maui.Android.Models.Device;

namespace Networking.Maui.Android;


public class SubnetScanner
{
    public static SubnetScanner Instance { get; } = new();
    public async Task<IEnumerable<Device>> FindDevicesAsync()
    {
        var asyncContext = new OnSubnetDeviceResultAsync();
        _ = Task.Run(() => SubnetDevices.FromLocalAddress().FindDevices(asyncContext));
        return await asyncContext.GetAwaitableTask().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Device>> FindDeviceByIpAsync(string ipAddress)
    {
        var asyncContext = new OnSubnetDeviceResultAsync();
        _ = Task.Run(() => SubnetDevices.FromIPAddress(ipAddress).FindDevices(asyncContext));
        return await asyncContext.GetAwaitableTask().ConfigureAwait(false);
    }
}