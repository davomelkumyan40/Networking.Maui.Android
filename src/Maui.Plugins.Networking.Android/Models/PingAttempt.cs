namespace Maui.Plugins.Networking.Android.Models;

public class PingAttempt
{
    public double Duration { get; set; }
    public string HostName { get; set; }
    public string IpAddress { get; set; }
    public bool IsReachable { get; set; }
}
