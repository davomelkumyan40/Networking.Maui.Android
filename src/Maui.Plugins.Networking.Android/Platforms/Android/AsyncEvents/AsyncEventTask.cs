using JavaObject = Java.Lang.Object;

namespace Maui.Plugins.Networking.Android.AsyncEvents;

internal class AsyncEventTask<T> : JavaObject
{
    protected TaskCompletionSource<T> CompletionSource { get; } = new();
    public Task<T> GetAwaitableTask() => CompletionSource.Task;
}
