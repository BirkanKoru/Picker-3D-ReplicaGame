using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class for when the player arrives at the checkpoint, if objects are stuck etc. to push
public class Broom : MonoBehaviour
{
    [SerializeField] private GameObject turningTrigger = null;
    private Vector3 startPos;
    private bool isRestart = false;
    
    void Start()
    {
        startPos.x = transform.localPosition.x;
        startPos.y = transform.localPosition.y;
        startPos.z = transform.localPosition.z;
    }
    
    void FixedUpdate()
    {
        if(PlayerMovement.Instance.ForwardSpeed == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, turningTrigger.transform.position, Time.fixedDeltaTime * 1f);
            isRestart = true;
        }

        if (isRestart)
        {
            Invoke("RestartPosition", 2f);
        }
    }

    private void RestartPosition()
    {
        transform.localPosition = new Vector3(startPos.x, startPos.y, startPos.z);
        isRestart = false;
    }
}
