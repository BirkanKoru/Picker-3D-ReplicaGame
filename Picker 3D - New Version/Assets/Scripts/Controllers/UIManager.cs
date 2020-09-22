using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Restart level method for UI button
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Restart game method for UI button
    public void RestartGame()
    {
        PlayerPrefs.SetInt("WhichLevel", 0);
        PlayerPrefs.SetInt("Coins", 0);
        SceneManager.LoadScene(0);
    }
}
