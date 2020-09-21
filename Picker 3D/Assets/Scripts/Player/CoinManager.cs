using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] private TMP_Text coinTxt = null;

    private int coinCounter = 0;
    public int CoinCounter
    {
        get
        {
            return coinCounter;
        }

        set
        {
            coinCounter = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinCounter = PlayerPrefs.GetInt("Coins");
    }
    
    void Update()
    {
        coinTxt.text = coinCounter.ToString();
    }
}
