using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject finishedGameContainerGO = null;
    [SerializeField] private TMP_Text coinTxt = null;

    Setup setup;
    private int whichLevel;
    private int totalSceneCount;

    private void Start()
    {
        setup = Setup.Instance;

        totalSceneCount = setup.MapsPrefab.Length;
        whichLevel = setup.WhichLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //When finish the game
            if (whichLevel + 1 == totalSceneCount)
            {
                finishedGameContainerGO.SetActive(true);
                coinTxt.text = CoinManager.Instance.CoinCounter.ToString();
                
                Time.timeScale = 0f;
                
            }
            else //When finish the level
            {
                //Saving the coins collected by the player
                PlayerPrefs.SetInt("Coins", CoinManager.Instance.CoinCounter);

                
                whichLevel++;
                PlayerPrefs.SetInt("WhichLevel", whichLevel);

                //Restart The Scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
}
