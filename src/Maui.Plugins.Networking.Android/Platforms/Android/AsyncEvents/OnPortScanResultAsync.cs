using Java.Lang;
using IPortListener = Com.Stealthcopter.Networktools.PortScan.IPortListener;
using JavaObject = Java.Lang.Object;
using JavaException = Java.Lang.Exception;

namespace Maui.Plugins.Networking.Android.AsyncEvents;

internal class OnPortScanResultAsync : AsyncEventTask<IEnumerable<int>>, IPortListener
{
    private static object _lock = new object();
    public void OnFinished(IList<Integer> p0)
    {
        lock (_lock)
        {
            CompletionSource.SetResult(p0.Select(p => p.IntValue()).AsEnumerable());
        }
    }

    public void OnResult(int p0, bool p1)
    {
    }
}
