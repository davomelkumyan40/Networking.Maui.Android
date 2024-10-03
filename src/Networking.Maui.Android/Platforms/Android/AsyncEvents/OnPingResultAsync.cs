using Com.Stealthcopter.Networktools.Pinglib;
using IPingListener = Com.Stealthcopter.Networktools.Ping.IPingListener;
using JavaObject = Java.Lang.Object;
using JavaException = Java.Lang.Exception;
using PingAttempt = Networking.Maui.Android.Models.PingAttempt;
using JavaPingResult = Com.Stealthcopter.Networktools.Pinglib.PingResult;
using PingResult = Networking.Maui.Android.Models.PingResult;
using System.Collections.Concurrent;

namespace Networking.Maui.Android.AsyncEvents;

internal class OnPingResultAsync : AsyncEventTask<PingResult>, IPingListener
{
    private ConcurrentBag<PingAttempt> _result = new();
    private static object _lock = new object();

    public void OnError(JavaException p0)
    {
        throw p0 ?? new Exception("OnPingResultAsync.OnError Unknown Exception has been thrown");
    }

    public void OnFinished(PingStats p0)
    {
        lock (_lock)
        {
            var result = new PingResult()
            {
                Attempts = _result.AsEnumerable(),
                CanonicalHostName = p0.Address.CanonicalHostName,
                HostAddress = p0.Address.HostAddress,
                IsAnyLocalAddress = p0.Address.IsAnyLocalAddress,
                IsLinkLocalAddress = p0.Address.IsLinkLocalAddress,
                IsLoopbackAddress = p0.Address.IsLoopbackAddress,
                IsMCGlobal = p0.Address.IsMCGlobal,
                IsMCLinkLocal = p0.Address.IsMCLinkLocal,
                IsMCNodeLocal = p0.Address.IsMCNodeLocal,
                IsMCOrgLocal = p0.Address.IsMCNodeLocal,
                IsMCSiteLocal = p0.Address.IsMCSiteLocal,
                IsMulticastAddress = p0.Address.IsMulticastAddress,
                IsSiteLocalAddress = p0.Address.IsSiteLocalAddress,
            };
            CompletionSource.SetResult(result);
        }
    }

    public void OnResult(JavaPingResult p0)
    {
        _result.Add(new PingAttempt()
        {
            Duration = p0.TimeTaken,
            IsReachable = p0.IsReachable,
            HostName = p0.Address.HostName,
            IpAddress = p0.Address.HostAddress
        });
    }
}
