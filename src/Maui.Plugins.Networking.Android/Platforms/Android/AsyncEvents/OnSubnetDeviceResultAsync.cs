using static Com.Stealthcopter.Networktools.SubnetDevices;
using JavaObject = Java.Lang.Object;
using JavaException = Java.Lang.Exception;
using JDevice = Com.Stealthcopter.Networktools.Subnet.Device;
using Device = Maui.Plugins.Networking.Android.Models.Device;

namespace Maui.Plugins.Networking.Android.AsyncEvents;

internal class OnSubnetDeviceResultAsync : AsyncEventTask<IEnumerable<Device>>, IOnSubnetDeviceFound
{
    private static object _lock = new object();

    void IOnSubnetDeviceFound.OnDeviceFound(JDevice p0)
    {
    }

    void IOnSubnetDeviceFound.OnFinished(IList<JDevice> p0)
    {
        lock (_lock)
        {
            CompletionSource.SetResult(p0.Select(d =>
            new Device
            {
                Hostname = d.Hostname,
                Ipv4 = d.Ip,
                MacAddress = d.Mac,
                Time = d.Time
            }).ToList());
        }
    }
}
