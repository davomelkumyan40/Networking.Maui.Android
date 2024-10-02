using Com.Stealthcopter.Networktools;
using JPortScan = Com.Stealthcopter.Networktools.PortScan;
using Maui.Plugins.Networking.Android.AsyncEvents;
using Integer = Java.Lang.Integer;
using Maui.Plugins.Networking.Android.Enums;

namespace Maui.Plugins.Networking.Android;

public class PortScanner
{
    public static PortScanner Instance { get; } = new();
    public async Task<IEnumerable<int>> ScanAsync(string ipAddress, int[] ports = null, int timeout = 1000, TransportType transportType = TransportType.Tcp, int? usedThreadsCount = null)
    {
        OnPortScanResultAsync context = new OnPortScanResultAsync();
        _ = Task.Run(() =>
        {
            var req = JPortScan.OnAddress(ipAddress)
            .SetTimeOutMillis(timeout);
            if (ports == null || ports.Length == 0)
                req.SetPortsAll();
            else
                req.SetPorts(ports.Select(p => new Integer(p)).ToList());
            if (transportType == TransportType.Tcp)
                req.SetMethodTCP();
            else
                req.SetMethodUDP();
            if (usedThreadsCount.HasValue)
                req.SetNoThreads(usedThreadsCount.Value);
            req.DoScan(context);
        });

        return await context.GetAwaitableTask().ConfigureAwait(false);
    }

    public IEnumerable<int> Scan(string ipAddress, int[] ports = null, int timeout = 1000, TransportType transportType = TransportType.Tcp, int? usedThreadsCount = null)
    {
        var req = JPortScan.OnAddress(ipAddress)!.SetTimeOutMillis(timeout);
        if (ports == null || ports.Length == 0)
            req.SetPortsAll();
        else
            req.SetPorts(ports.Select(p => new Integer(p)).ToList());
        if (transportType == TransportType.Tcp)
            req.SetMethodTCP();
        else
            req.SetMethodUDP();
        if (usedThreadsCount.HasValue)
            req.SetNoThreads(usedThreadsCount.Value);
        return req.DoScan()!.Select(p => p.IntValue()).ToList();
    }

    public async Task<bool> IsPortOpenAsync(string ipAddress, int port, int timeout = 1000, TransportType transportType = TransportType.Tcp)
    {
        return (await ScanAsync(ipAddress, [port], timeout, transportType).ConfigureAwait(false)).Contains(port);
    }

    public bool IsPortOpen(string ipAddress, int port, int timeout = 1000, TransportType transportType = TransportType.Tcp)
    {
        return Scan(ipAddress, [port], timeout, transportType).Contains(port);
    }
}
