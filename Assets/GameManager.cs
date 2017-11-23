using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int randomSeed = 0;

    private System.Random _random;

    public System.Random Random
    {
        get
        {
            return _random;
        }
    }

    // Use this for initialization
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
    }
}
