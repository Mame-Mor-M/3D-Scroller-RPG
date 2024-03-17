using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    [SerializeField] float panSpeed;
    public Vector3 offset;
    private Vector3 orgOffset;
    [SerializeField] Vector3 combatOffset;
    [SerializeField] float engageDistance;
    public GameObject[] Enemies;
    public bool inCombat = false;


    private void Start()
    {
        orgOffset = offset;
    }
    void Update()
    {
        FindClosestEnemy();

        if (offset.x > 0 && inCombat == false) // Checks if the camera offset on the X-axis is greater than 0
        {
            offset.x = offset.x - panSpeed * Time.deltaTime; // Moves camera towards the player until they are cenetered

            if (offset.x < 0)// Stops camera movement once player is centered
            {
                offset.x = 0;
            }
        }

        else if (offset.x < 0 && inCombat == false) // Checks if the camera offset on the X-axis is less than 0
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


    public GameObject FindClosestEnemy()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in Enemies)
        {
            
            if (Vector3.Distance(player.transform.position, enemy.transform.position) < engageDistance)
            {
                Debug.Log(Vector3.Distance(player.transform.position, enemy.transform.position));
                inCombat = true;
                
                if (offset.z <= combatOffset.z)
                {
                    offset.z = combatOffset.z;    
                }
                else
                {
                    offset.z += -20f * Time.deltaTime;
                }

                if (offset.y >= combatOffset.y)
                {
                    offset.y = combatOffset.y;
                }

                else
                {
                    offset.y += 8f * Time.deltaTime;
                }

                if (offset.x >= combatOffset.x)
                {
                    offset.x = combatOffset.x;
                }
                else
                {
                    offset.x += 7f * Time.deltaTime;
                }
            }
            else
            {
                inCombat = false;
                if (offset.z >= orgOffset.z)
                {
                    offset.z = orgOffset.z;
                }
                else
                {
                    offset.z += 20f * Time.deltaTime;
                }

                if (offset.y <= orgOffset.y)
                {
                    offset.y = orgOffset.y;
                }

                else
                {
                    offset.y += -8f * Time.deltaTime;
                }

                if (offset.x <= orgOffset.x)
                {
                    offset.x = orgOffset.x;
                }
                else
                {
                    offset.x += -6f * Time.deltaTime;
                }
            }
        }

        return null;
    }
}
