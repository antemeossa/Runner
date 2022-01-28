using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour
{

    [SerializeField]
    private float desiredForwardSpeed = 10f;
    private float sideSpeed = 50f;

    private Rigidbody rb;

    private float currentSpeed = 0f;
    private float maxSpeed;

    private Vector3 move;

    private int desiredLane = 1; //0:left, 1: middle, 2: right
    public float laneDistance = 2.5f; //distance between two lanes

    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3) { 
                       desiredLane= 2; 
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, sideSpeed*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * desiredForwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
        
    }

    private void run()
    {

    }
}
