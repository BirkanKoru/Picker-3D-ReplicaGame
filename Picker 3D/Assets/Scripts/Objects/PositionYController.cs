using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionYController : MonoBehaviour
{
    private Rigidbody rb;
    private float startPosY;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosY = transform.position.y;
    }
    
    void Update()
    {
        if(transform.position.y > startPosY)
        {
            rb.MovePosition(new Vector3(transform.position.x, startPosY, transform.position.z));
        }
    }
}
