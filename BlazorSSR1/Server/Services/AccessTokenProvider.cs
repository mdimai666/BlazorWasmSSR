using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Threading.Tasks;

namespace BlazorSSR1.Server.Services;

/// <summary>
/// Заглушка для SSR
/// </summary>
public class AccessTokenProvider : IAccessTokenProvider
{
    public ValueTask<AccessTokenResult> RequestAccessToken()
    {
        throw new NotImplementedException();
    }

    public ValueTask<AccessTokenResult> RequestAccessToken(AccessTokenRequestOptions options)
    {
        throw new NotImplementedException();
    }
}
