using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    [SerializeField] float panSpeed;
    public Vector3 offset;

    void Update()
    {

        if (offset.x > 0) // Checks if the camera offset on the X-axis is greater than 0
        {
            offset.x = offset.x - panSpeed * Time.deltaTime; // Moves camera towards the player until they are cenetered

            if (offset.x < 0)// Stops camera movement once player is centered
            {
                offset.x = 0;
            }
        }

        else if (offset.x < 0) // Checks if the camera offset on the X-axis is less than 0
        {
            offset.x = offset.x + panSpeed * Time.deltaTime; // Moves camera towards the player until they are cenetered

            if (offset.x > 0) // Stops camera movement once player is centered
            {
                offset.x = 0; 
            }
        }
        if (player.position.z + offset.z < offset.z) // Only follow the player on the Z axis to a certain point.
        {
            

            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z); // Camera follows the player with specified offset position
        }
        
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
    }
}
