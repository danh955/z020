namespace z020.Website.Services;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class SessionService(ProtectedSessionStorage sessionStorage, ProtectedLocalStorage localStorage)
{
    private const string LocalStorageBrowserIdKey = "BrowserId";
    private const string SessionStorageSessionIdKey = "SessionId";

    private readonly ProtectedLocalStorage localStorage = localStorage;
    private readonly ProtectedSessionStorage sessionStorage = sessionStorage;

    public string PlayerId { get; private set; } = string.Empty;

    /// <summary>
    /// Setup the session service.
    /// Call this on a OnAfterRenderAsync event only on the firstRender.
    /// </summary>
    /// <returns></returns>
    public async Task SetupAfterRenderAsync()
    {
        if (string.IsNullOrWhiteSpace(PlayerId))
        {
            PlayerId = await GetSessionId();
        }
    }

    /// <summary>
    /// Get a unique browser ID.
    /// </summary>
    /// <returns>Browser ID</returns>
    private async ValueTask<string> GetBrowserID()
    {
        var result = await localStorage.GetAsync<string>(LocalStorageBrowserIdKey);
        if (result.Success && result.Value != null)
        {
            return result.Value;
        }

        string browserId = Guid.NewGuid().ToString();
        await localStorage.SetAsync(LocalStorageBrowserIdKey, browserId);
        return browserId;
    }

    /// <summary>
    /// Get a unique session ID.
    /// </summary>
    /// <returns>Session ID.</returns>
    private async Task<string> GetSessionId()
    {
        var result = await sessionStorage.GetAsync<string>(SessionStorageSessionIdKey);
        if (result.Success && result.Value != null)
        {
            return result.Value;
        }

        string sessionId = Guid.NewGuid().ToString();
        await sessionStorage.SetAsync(SessionStorageSessionIdKey, sessionId);
        return sessionId;
    }
}