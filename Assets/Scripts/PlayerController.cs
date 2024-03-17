using System.Collections;
using System.Collections.Generic;
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


    //Other
    private Rigidbody rb;
    
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
        /*if (horizontal < 0) // Check if the player is moving left
        {
             // Camera moves away from player to create offset visual

            if (cam.inCombat == false)
            {
                cam.offset.x += panSpeed * Time.deltaTime;
            }
            if (cam.offset.x >= maxCamDist && cam.inCombat == false) // Freeze camera at offset if max distance from player is reached
            {
                cam.offset.x = maxCamDist; // Set cam offset to the max distance to prevent a large offset.
            }
        }*/

        if (horizontal > 0) //  Check if the player is moving right
        {
            if(cam.inCombat == false)
            {
                cam.offset.x -= panSpeed * Time.deltaTime;
            }
              // Camera moves away from player to create offset visual
            if (cam.offset.x <= maxCamDist * -1 && cam.inCombat == false) // Freeze camera at offset if max distance from player is reached
            {
                cam.offset.x = maxCamDist*-1; // Set cam offset to the max distance to prevent a large offset.
            }
        }
    }
}
