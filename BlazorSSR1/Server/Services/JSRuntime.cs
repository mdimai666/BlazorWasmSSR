using Microsoft.JSInterop;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorSSR1.Server.Services;

/// <summary>
/// Заглушка для SSR
/// </summary>
public class JSRuntime : IJSRuntime
{
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
    {
        return new ValueTask<TValue>();
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
    {
        return new ValueTask<TValue>();
    }
}
