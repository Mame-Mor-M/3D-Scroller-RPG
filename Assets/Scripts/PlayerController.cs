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
    private Vector3 targetRot;
    private bool facingLeft;
    private bool facingUp;
    private bool facingDown;

    //Other
    private Rigidbody rb;
    public CombatZoneController combat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * walkSpeed,0 , vertical * walkSpeed); // Allows user input to move the player
        
        if(horizontal < 0)
        {
            facingUp = false;
            facingDown = false;
            if (cam.inCombat == true)
            {
                if (combat.leftCombat == true || combat.centerCombat == true)
                {
                    facingLeft = true;
                    targetRot = transform.eulerAngles + 180f * Vector3.up; // Makes rotation of player relative to their current position. Sets target rotation to 180 left of the player
                }
                else
                {
                    Debug.Log("CAN'T FACE LEFT WHILE ENEMIES ARE ON YOUR RIGHT");
                }
            }
            else
            {
                facingLeft = true;
                targetRot = transform.eulerAngles + 180f * Vector3.up; // Makes rotation of player relative to their current position. Sets target rotation to 180 left of the player
            }
           
          
        }
        else if (horizontal > 0)
        {
            facingUp = false;
            facingDown = false;
            if (cam.inCombat == true)
            {
                if (combat.rightCombat == true || combat.centerCombat == true)
                {
                    facingLeft = false;
                    targetRot = transform.eulerAngles - 180f * Vector3.up; // Makes rotation of player relative to their current position. Sets target rotation to 180 left of the player
                }
                else
                {
                    Debug.Log("CAN'T FACE RIGHT WHILE ENEMIES ARE ON YOUR RIGHT");
                }
            }
            else
            {
                facingLeft = false;
                targetRot = transform.eulerAngles - 180f * Vector3.up; // Makes rotation of player relative to their current position. Sets target rotation to 180 right of the player
            }
            

        }

        if (vertical > 0 && cam.inCombat == false)
        {
            facingUp = true;
            facingDown = false;
            if(facingLeft == true)
            {
                targetRot = transform.eulerAngles + 90f * Vector3.up;
                
            }
            else
            {
                targetRot = transform.eulerAngles - 90f * Vector3.up;
                
            }
            
        }

        else if (vertical < 0 && cam.inCombat == false)
        {
            facingUp = false;
            facingDown = true;
            if (facingLeft == true)
            {
                targetRot = transform.eulerAngles - 90f * Vector3.up;
                
            }
            else
            {
                targetRot = transform.eulerAngles + 90f * Vector3.up;
                
            }
        }


        turnPlayer();
        Debug.Log(transform.eulerAngles.y);
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
        if (facingLeft == true && transform.eulerAngles.y >= 180 && facingUp == false && facingDown == false) // EULER ANGLES ARE RELATIVE TO CURRENT ROTATION. Sets player to face left once it does a full 180 degree rotation
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        else if (facingLeft == false && transform.eulerAngles.y >= 180 && facingUp == false && facingDown == false) // Sets player to face right once it has does a full 180 degree rotation
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }



        if ((facingLeft == true && transform.eulerAngles.y >= 270 && facingUp == true) || (facingLeft == false && transform.eulerAngles.y <= 270 && facingUp == true)) // EULER ANGLES ARE RELATIVE TO CURRENT ROTATION. Sets player to face left once it does a full 180 degree rotation
        {
            facingLeft = false;
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        else if ((facingLeft == true && transform.eulerAngles.y <= 90 && facingDown == true) || (facingLeft == false && transform.eulerAngles.y >= 90 && facingDown == true)) // EULER ANGLES ARE RELATIVE TO CURRENT ROTATION. Sets player to face left once it does a full 180 degree rotation
        {
            facingLeft = false;
            transform.eulerAngles = new Vector3(0, 90, 0);
        }


        /*else
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRot, turnSpeed * Time.deltaTime); // lerp to new angles
        }*/
    }
}
