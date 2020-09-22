using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPieceMovement : MonoBehaviour
{
    [SerializeField] private float turningSpeed;
    [SerializeField] private int turningDirection;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, turningSpeed * turningDirection * Time.fixedDeltaTime, 0));
    }
}
