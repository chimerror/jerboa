public enum Rank
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
}

public static class RankExtensions
{
    public static string GetAssetName(this Rank rank)
    {
        switch (rank)
        {
            case Rank.Ace:
                return "A";

            case Rank.Jack:
                return "J";

            case Rank.Queen:
                return "Q";

            case Rank.King:
                return "K";

            default:
                return ((int)rank).ToString();
        }
    }
}
