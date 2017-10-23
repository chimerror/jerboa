using System.IO;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
    [SerializeField]
    private bool _faceUp = true;

    [SerializeField]
    private Suit _suit;

    [SerializeField]
    private Rank _rank;

    [SerializeField]
    private Back _back;

    private SpriteRenderer _spriteRenderer;
    private AssetBundle _cardSprites;

    public bool FaceUp
    {
        get
        {
            return _faceUp;
        }

        set
        {
            _faceUp = value;
            UpdateCardSprite();
        }
    }

    public Suit Suit
    {
        get
        {
            return _suit;
        }

        set
        {
            _suit = value;
            UpdateCardSprite();
        }
    }

    public Rank Rank
    {
        get
        {
            return _rank;
        }

        set
        {
            _rank = value;
            UpdateCardSprite();
        }
    }

    public Back Back
    {
        get
        {
            return _back;
        }

        set
        {
            _back = value;
            UpdateCardSprite();
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

	private void Start()
    {
        _cardSprites = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles/cards"));
        Debug.Assert(_cardSprites != null, "Couldn't load cards!");
        UpdateCardSprite();
    }

    private void UpdateCardSprite()
    {
        string path;
        if (_faceUp)
        {
            path = string.Format("assets/cards/card{0}{1}.png", _suit.GetAssetName(), _rank.GetAssetName());
        }
        else
        {
            path = string.Format("assets/cards/cardBack{0}.png", _back.GetAssetName());
        }

        var cardSprite = _cardSprites.LoadAsset<Sprite>(path);
        Debug.AssertFormat(cardSprite != null, "Unable to load card: {0}", path);
        _spriteRenderer.sprite = cardSprite;
    }
}
