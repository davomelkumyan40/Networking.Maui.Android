using Com.Stealthcopter.Networktools.Pinglib;
using static Com.Stealthcopter.Networktools.Ping;
using PingAttempt = Networking.Maui.Android.Models.PingAttempt;
using JavaPingResult = Com.Stealthcopter.Networktools.Pinglib.PingResult;
using JavaObject = Java.Lang.Object;
using JavaException = Java.Lang.Exception;
using PingResult = Networking.Maui.Android.Models.PingResult;
using System.Collections.Concurrent;

namespace Networking.Maui.Android.Events;

internal class OnPingResult : JavaObject, IPingListener
{
    private ConcurrentBag<PingAttempt> _attempts = new();
    private PingResult _result = new();
    private object _lock = new object();

    public ManualResetEvent Waiter { get; } = new(false);

    public void OnError(JavaException p0)
    {
        throw p0 ?? new Exception("OnPingResultAsync.OnError Unknown Exception has been thrown");
    }

    public void OnFinished(PingStats p0)
    {
        lock (_lock)
        {
            _result = new PingResult()
            {
                Attempts = _attempts.AsEnumerable(),
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
            Waiter.Set();
        }
    }

    public void OnResult(JavaPingResult p0)
    {
        _attempts.Add(new PingAttempt()
        {
            Duration = p0.TimeTaken,
            IsReachable = p0.IsReachable,
            HostName = p0.Address.HostName,
            IpAddress = p0.Address.HostAddress
        });
    }

    public PingResult GetResult() => _result;
}
