using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card : MonoBehaviour
{
    private static AssetBundle CardSprites;

    public bool faceUp = true;
    public Suit suit = Suit.Spades;
    public Rank rank = Rank.Ace;
    public Back back = Back.Red;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        if (CardSprites == null)
        {
            CardSprites = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles/cards"));
            Debug.Assert(CardSprites != null, "Couldn't load cards!");
        }
    }

    private void Update()
    {
        string path;
        if (faceUp)
        {
            path = string.Format("assets/cards/card{0}{1}.png", suit.GetAssetName(), rank.GetAssetName());
        }
        else
        {
            path = string.Format("assets/cards/cardBack{0}.png", back.GetAssetName());
        }

        var cardSprite = CardSprites.LoadAsset<Sprite>(path);
        Debug.AssertFormat(cardSprite != null, "Unable to load card: {0}", path);
        _image.sprite = cardSprite;
    }
}
