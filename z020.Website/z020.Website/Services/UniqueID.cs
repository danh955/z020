namespace z020.Website.Services;

public static class UniqueID
{
    private static readonly object locker = new();
    private static long lastUniqueID = 0;

    /// <summary>
    /// Get a unique ID for this system.
    /// </summary>
    /// <returns>A unique ID.</returns>
    public static long Get()
    {
        lock (locker)
        {
            if (lastUniqueID == 0)
            {
                lastUniqueID = DateTime.UtcNow.Ticks;
                return lastUniqueID;
            }

            lastUniqueID++;
            return lastUniqueID;
        }
    }
}