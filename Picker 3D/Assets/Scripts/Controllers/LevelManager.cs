using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject finishedGameContainerGO;
    [SerializeField] private TMP_Text coinTxt;

    private int totalSceneCount;

    private void Start()
    {
        totalSceneCount = SceneManager.sceneCountInBuildSettings;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //When finish the game
            if (SceneManager.GetActiveScene().buildIndex + 1 == totalSceneCount)
            {
                finishedGameContainerGO.SetActive(true);
                coinTxt.text = CoinManager.Instance.CoinCounter.ToString();
                
                Time.timeScale = 0f;
                
            }
            else //When finish the level
            {
                //Saving the coins collected by the player
                PlayerPrefs.SetInt("Coins", CoinManager.Instance.CoinCounter);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}
