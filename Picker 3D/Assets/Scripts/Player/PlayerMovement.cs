using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private float forwardSpeed = 1f;
    public float ForwardSpeed
    {
        get
        {
            return forwardSpeed;
        }

        set
        {
            forwardSpeed = value;
        }
    }
    [SerializeField] private bool forwardMove = false;

    [SerializeField] private float touchSpeed = 0.5f;
    public float TouchSpeed
    {
        get
        {
            return touchSpeed;
        }

        set
        {
            touchSpeed = value;
        }
    }

    private Rigidbody rb;
    private Vector3 moveVector;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
    void FixedUpdate()
    {
        //Forward Movement
        if (forwardMove)
        {
            moveVector.z = transform.position.z + (forwardSpeed * Time.fixedDeltaTime);
        }
        
        //Left and right Movement
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            forwardMove = true;

            if(touch.phase == TouchPhase.Moved)
            {
                moveVector.x = transform.position.x + (touch.deltaPosition.x * touchSpeed * Time.fixedDeltaTime);

                if(moveVector.x > 0.32f)
                {
                    moveVector.x = 0.32f;
                }

                if(moveVector.x < -1.6f)
                {
                    moveVector.x = -1.6f;
                }
            }
        }

        rb.MovePosition(moveVector);
    }
}
