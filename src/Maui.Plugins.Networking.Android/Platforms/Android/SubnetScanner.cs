using Com.Stealthcopter.Networktools;
using Maui.Plugins.Networking.Android.AsyncEvents;
using Device = Maui.Plugins.Networking.Android.Models.Device;

namespace Maui.Plugins.Networking.Android;


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