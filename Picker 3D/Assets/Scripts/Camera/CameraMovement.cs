using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private int Offset = -2;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {   
        //
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + Offset);
    }
}
