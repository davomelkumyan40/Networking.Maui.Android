
namespace Networking.Maui.Android.Models;

public class PingResult
{
    public IEnumerable<PingAttempt> Attempts { get; init; }
    public bool IsAnyLocalAddress { get; init; }

    public bool IsSiteLocalAddress { get; init; }

    public bool IsMulticastAddress { get; init; }

    public bool IsMCSiteLocal { get; init; }

    public bool IsMCOrgLocal { get; init; }

    public bool IsMCNodeLocal { get; init; }

    public bool IsMCLinkLocal { get; init; }

    public bool IsMCGlobal { get; init; }

    public bool IsLoopbackAddress { get; init; }

    public bool IsLinkLocalAddress { get; init; }

    public string HostAddress { get; init; }
    public string CanonicalHostName { get; init; }
}
