using Networking.Maui.Android.AsyncEvents;
using Networking.Maui.Android.Events;
using PingAttempt = Networking.Maui.Android.Models.PingAttempt;
using PingResult = Networking.Maui.Android.Models.PingResult;

namespace Networking.Maui.Android;

public class Pinger
{
    public static Pinger Instance { get; } = new(); 
    public async Task<PingResult> PingAsync(string ipAddress, int timeout = 1000, int pingCount = 1)
    {
        var asyncContext = new OnPingResultAsync();
        _ = Task.Run(() =>
        {
            Com.Stealthcopter.Networktools.Ping.OnAddress(ipAddress)
        .SetTimeOutMillis(timeout)
        .SetTimes(pingCount)
        .DoPing(asyncContext);
        });

        return await asyncContext.GetAwaitableTask().ConfigureAwait(false);
    }

    public PingResult Ping(string ipAddress, int timeout = 1000, int pingCount = 1)
    {
        var context = new OnPingResult();
        Thread workerThread = new Thread(() =>
        {
            Com.Stealthcopter.Networktools.Ping.OnAddress(ipAddress)
            .SetTimeOutMillis(timeout)
            .SetTimes(pingCount)
            .DoPing(context);
            context.Waiter.WaitOne();
        });
        workerThread.Start();
        workerThread.Join();
        return context.GetResult();
    }
}
