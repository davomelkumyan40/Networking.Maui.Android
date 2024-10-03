using JavaObject = Java.Lang.Object;

namespace Networking.Maui.Android.AsyncEvents;

internal class AsyncEventTask<T> : JavaObject
{
    protected TaskCompletionSource<T> CompletionSource { get; } = new();
    public Task<T> GetAwaitableTask() => CompletionSource.Task;
}
