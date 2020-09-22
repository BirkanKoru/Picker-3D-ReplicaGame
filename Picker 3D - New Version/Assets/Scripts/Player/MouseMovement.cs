using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public static MouseMovement Instance;

    [SerializeField] private float forwardSpeed = 3f;
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

    [SerializeField] private float mouseSpeed = 10f;
    public float MouseSpeed
    {
        get
        {
            return mouseSpeed;
        }

        set
        {
            mouseSpeed = value;
        }
    }

    private Rigidbody rb;
    private Vector3 moveVector;

    private Vector3 mouseInput;
    private float objXPos;
    private float movZ;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnMouseDrag()
    {
        mouseInput.x = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        moveVector.z = transform.position.z + (forwardSpeed * Time.fixedDeltaTime);
        
        moveVector.x = transform.position.x + (mouseInput.x * mouseSpeed * Time.fixedDeltaTime);

        //to stay on the track
        if (moveVector.x > 0.32f)
        {
            moveVector.x = 0.32f;
        }
        else if (moveVector.x < -1.6f)
        {
            moveVector.x = -1.6f;
        }

        rb.MovePosition(moveVector);
    }
}
