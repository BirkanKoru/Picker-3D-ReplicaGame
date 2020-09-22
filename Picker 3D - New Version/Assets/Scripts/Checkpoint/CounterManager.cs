using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterManager : MonoBehaviour
{
    //Checkpoint point infoTxt "0 / 10"
    [SerializeField] private TMP_Text infoTxt = null;
    //How many objects player needs for pass
    [SerializeField] private int checkpointNeedsObject = 0;
    public int CheckPointNeedsObject
    {
        get
        {
            return checkpointNeedsObject;
        }
    }

    private void Start()
    {
        infoTxt.text = "0 / " + checkpointNeedsObject;
    }

    //Counting objects brought by the player
    private void OnTriggerEnter(Collider other)
    {
        CheckpointsManager.Instance.ObjectCount++;
        infoTxt.text = CheckpointsManager.Instance.ObjectCount + " / " + checkpointNeedsObject;
        //Calculating Coin
        CoinManager.Instance.CoinCounter++;
        Destroy(other.gameObject, 0.5f);
    }
}
