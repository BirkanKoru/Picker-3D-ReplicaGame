using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningManager : MonoBehaviour
{
    public static TurningManager Instance;

    [SerializeField] private GameObject turningPiece1 = null;
    public GameObject SetTurningPiece1
    {
        set
        {
            turningPiece1.SetActive(false);
        }
    }

    [SerializeField] private GameObject turningPiece2 = null;
    public GameObject SetTurningPiece2
    {
        set
        {
            turningPiece2.SetActive(false);
        }
    }
    
    void Start()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TurningTrigger")
        {
            turningPiece1.SetActive(true);
            turningPiece2.SetActive(true);

            Destroy(other.gameObject);
        }    
    }
}
