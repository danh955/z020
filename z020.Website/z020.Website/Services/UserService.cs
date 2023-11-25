namespace z020.Website.Services;

using Blazored.LocalStorage;

public class UserService(ILocalStorageService localStorage)
{
    private const string StorageUserIdKey = "UserId";

    private readonly ILocalStorageService localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));

    /// <summary>
    /// Get the user ID.
    /// </summary>
    /// <returns></returns>
    public async ValueTask<string> GetUserID()
    {
        string? userId = await localStorage.GetItemAsync<string?>(StorageUserIdKey);

        if (string.IsNullOrEmpty(userId))
        {
            userId = UniqueID.Get().ToString();
            await localStorage.SetItemAsync(StorageUserIdKey, userId);
        }

        return userId;
    }
}