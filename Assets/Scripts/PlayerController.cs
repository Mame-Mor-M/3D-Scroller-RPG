using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;
    private float horizontal;
    private float vertical;
    private bool onGround;


    //Camera
    [SerializeField] float panSpeed;
    [SerializeField] float maxCamDist;
    public CameraController cam;

    // Player Rotation
    [SerializeField] float turnSpeed;
    public Vector3 rightRot;
    private Vector3 targetRot;
    public Vector3 leftRot;
    private bool facingLeft;

    //Other
    private Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightRot  = new Vector3 (0, 0, 0);
        leftRot = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * walkSpeed,0 , vertical * walkSpeed); // Allows user input to move the player
        
        if(horizontal < 0)
        {
            facingLeft = true;
            targetRot = transform.eulerAngles + 180f * Vector3.up;
          
        }
        else if (horizontal > 0)
        {
            facingLeft = false;
            targetRot = transform.eulerAngles - 180f * Vector3.up;

        }


        turnPlayer();
        Debug.Log(facingLeft);
    }

    void turnPlayer()
    {
        /*if (transform.eulerAngles != targetRot.eulerAngles)
        {
            transform.Rotate(Vector3.up, 5 * turnSpeed);
        }
        else
        {
            transform.eulerAngles = targetRot.eulerAngles;
        }*/

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRot, turnSpeed * Time.deltaTime); // lerp to new angles
        if (facingLeft == true && transform.eulerAngles.y >= 180)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (facingLeft == false && transform.eulerAngles.y <= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRot, turnSpeed * Time.deltaTime); // lerp to new angles
        }
    }
}
