public enum Back
{
    Red,
    Blue,
    Green,
}

public static class BackExtensions
{
    public static string GetAssetName(this Back back)
    {
        return back.ToString();
    }
}
