using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerManager : MonoBehaviour
{
    //If the player arrives at the checkpoint
    //Stop Point
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Stopping the player at the checkpoint
            //PlayerMovement.Instance.ForwardSpeed = 0;
            //PlayerMovement.Instance.TouchSpeed = 0;
            MouseMovement.Instance.ForwardSpeed = 0;
            MouseMovement.Instance.MouseSpeed = 0;

            //Turning pieces setActive(false)
            TurningManager.Instance.SetTurningPiece1 = null;
            TurningManager.Instance.SetTurningPiece2 = null;

            this.gameObject.SetActive(false);
        }
    }
}
