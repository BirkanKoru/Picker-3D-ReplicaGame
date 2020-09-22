using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public static Setup Instance;

    [SerializeField] private GameObject[] mapsPrefab = null;
    public GameObject[] MapsPrefab
    {
        get
        {
            return mapsPrefab;
        }
    }

    [SerializeField] private GameObject[] objectsPrefab = null;

    [SerializeField] private GameObject playerPrefab = null;

    private int whichLevel = 0;
    public int WhichLevel
    {
        get
        {
            return whichLevel;
        }

        set
        {
            whichLevel = value;
        }
    }

    private void Awake()
    {
        whichLevel = PlayerPrefs.GetInt("WhichLevel");

        Instantiate(mapsPrefab[whichLevel], transform.position, Quaternion.identity);
        Instantiate(objectsPrefab[whichLevel], transform.position, Quaternion.identity);
        Instantiate(playerPrefab);

        Instance = this;
    }
}
