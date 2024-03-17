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
        

        
    }
}
