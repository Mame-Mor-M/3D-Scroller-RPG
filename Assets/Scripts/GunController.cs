using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Bullet Properties
    public Rigidbody bullet;
    public GameObject barrelPos;
    public float bulletVelocity;
    //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)) { // Shoot on left click
            Rigidbody shot = Instantiate(bullet, new Vector3(barrelPos.transform.position.x, barrelPos.transform.position.y, barrelPos.transform.position.z), Quaternion.identity); // Create bullet object
            shot.velocity = transform.right * bulletVelocity; // Launch bullet from barrel at certain speed
            Debug.Log(shot.velocity);
            
        }
        
    }
}
