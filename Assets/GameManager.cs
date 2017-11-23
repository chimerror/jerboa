using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int randomSeed = 0;
    public Shoe shoe;
    public Button newHandButton;
    public Hand punterHand;
    public Hand bankerHand;
    public float dealDelay = 1.0f;

    private System.Random _random;
    private GameState _gameState = GameState.NewHand;

    public System.Random Random
    {
        get
        {
            return _random;
        }
    }

    public void PunterResponds(bool hit)
    {
        punterHand.buttons.gameObject.SetActive(false);
        bankerHand.buttons.gameObject.SetActive(true);
        if (hit)
        {
            shoe.Deal(punterHand);
        }
        _gameState = GameState.AskingIfBankerHits;
        if (bankerHand.player is AiPlayer)
        {
            BankerResponds((bankerHand.player as AiPlayer).HitOrStay(punterHand, true));
        }
    }

    public void BankerResponds(bool hit)
    {
        bankerHand.buttons.gameObject.SetActive(false);
        if (hit)
        {
            shoe.Deal(bankerHand);
        }
        _gameState = GameState.DeterminingWinner;
        DetermineWinner();
    }

    public void StartNewHand()
    {
        punterHand.DiscardCards();
        bankerHand.DiscardCards();
        _gameState = GameState.NewHand;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogAssertion("Two GameManagers present!");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (randomSeed == 0)
        {
            if (UnityEngine.Random.Range(0, 1) == 0)
            {
                randomSeed = UnityEngine.Random.Range(int.MinValue, 0);
            }
            else
            {
                randomSeed = UnityEngine.Random.Range(1, int.MaxValue);
            }
        }

        _random = new System.Random(randomSeed);
        UnityEngine.Random.InitState(randomSeed);

        punterHand.player = new HumanPlayer();
        punterHand.player.hand = punterHand;
        bankerHand.player = new HumanPlayer();
        bankerHand.player.hand = bankerHand;
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.NewHand:
                newHandButton.gameObject.SetActive(false);
                _gameState = GameState.DealingCards;
                StartCoroutine(DealStartingHands());
                break;

            case GameState.CheckingImmediateWinners:
                if (punterHand.Value == 8 || punterHand.Value == 9 ||
                    bankerHand.Value == 8 || bankerHand.Value == 9)
                {
                    DetermineWinner();
                }
                else
                {
                    _gameState = GameState.AskingIfPunterHits;

                    if (punterHand.player is AiPlayer)
                    {
                        PunterResponds((punterHand.player as AiPlayer).HitOrStay(bankerHand, false));
                    }
                    else
                    {
                        punterHand.buttons.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }

    private IEnumerator DealStartingHands()
    {
        punterHand.buttons.gameObject.SetActive(false);
        bankerHand.buttons.gameObject.SetActive(false);
        shoe.Deal(punterHand);
        yield return new WaitForSeconds(dealDelay);
        shoe.Deal(bankerHand);
        yield return new WaitForSeconds(dealDelay);
        shoe.Deal(punterHand);
        yield return new WaitForSeconds(dealDelay);
        shoe.Deal(bankerHand);
        yield return new WaitForSeconds(dealDelay);
        _gameState = GameState.CheckingImmediateWinners;

    }

    private void DetermineWinner()
    {
        _gameState = GameState.HandOver;
        newHandButton.gameObject.SetActive(true);
        if (bankerHand.Value < punterHand.Value)
        {
            Debug.Log("Punter wins!");
        }
        else if (bankerHand.Value == punterHand.Value)
        {
            Debug.Log("Push!");
        }
        else
        {
            Debug.Log("Banker wins!");
        }
    }
}
