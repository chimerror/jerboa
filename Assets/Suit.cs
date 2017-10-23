public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades,
}

public static class SuitExtensions
{
    public static string GetAssetName(this Suit suit)
    {
        return suit.ToString();
    }
}
