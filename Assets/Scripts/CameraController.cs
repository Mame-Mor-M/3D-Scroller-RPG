using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Player Stuff
    public Transform player;
    [SerializeField] float panSpeed;

    // Offset settings
    public Vector3 offset;
    private Vector3 orgOffset;
    [SerializeField] Vector3 combatOffset;

    // Combat Settings
    [SerializeField] float engageDistance;
    public GameObject[] Enemies;
    public bool inCombat = false;
    public GameObject closestEnemy;

    // Other Stuff
    private Vector3 _currentVelocity = Vector3.zero;


    private void Start()
    {
        orgOffset = offset; // Save the original offset under its own variable.
    }
    void Update()
    {
        FindClosestEnemy(); // Search for the closest enemy
        if(closestEnemy != null) // Only enter the combat cam if there is an enemy present
        {
            CombatCam(closestEnemy); // Enter the combat cam function
        }
        else // Not in combat state
        {
            inCombat = false; 
        }
        
        Vector3 playerPos = player.position + offset; // Save the player position under a variable. This would be its original position + the cam offset
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref _currentVelocity, panSpeed); // Follow the player using smooth damp so the camera lags slightly behind
    }


    public GameObject FindClosestEnemy()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Add all objects with the Enemy tag to an enemy array

        
        foreach (GameObject enemy in Enemies) // Search through the enemy array
        {
            float closestDist = Mathf.Infinity; // Initial float value for the closest enemy distance
            float currentDist = Vector3.Distance(player.transform.position, enemy.transform.position); // current enemies distance
            if (closestDist > currentDist) { // Calculate whether or not the current enemy in the array has a lower distance to the player than the closest enemy in the array
                closestDist = currentDist; // If so, set closest enemy distance to the current enemy distance
                closestEnemy = enemy; // Set the closest enemy object to the current enemy object
            }
            
        }
        if (inCombat == false)
        {
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
        }// Reset the camera back to the non-combat cam when not in combat
        return closestEnemy; // Return the closest enemy
    }

    void CombatCam(GameObject enemy) 
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) < engageDistance) // Check if the closest enemy is within combat range
        {
            Debug.Log(Vector3.Distance(player.transform.position, enemy.transform.position)); // Output distance in the debug log
            inCombat = true; // Combat status is true

            if (offset.z <= combatOffset.z) // Set the cam offset to the combat offset once the z value is reached or passed
            {
                offset.z = combatOffset.z;
            }
            else
            {
                offset.z += -20f * Time.deltaTime; // Pan towards the 'z' combat offset
            }

            if (offset.y >= combatOffset.y) // Set the cam offset to the combat offset once the y value is reached or passed
            {
                offset.y = combatOffset.y;
            }

            else
            {
                offset.y += 8f * Time.deltaTime;  // Pan towards the 'y' combat offset
            }

            if (offset.x >= combatOffset.x) // Set the cam offset to the combat offset once the x value is reached or passed
            {
                offset.x = combatOffset.x;
            }
            else
            {
                offset.x += 7f * Time.deltaTime;  // Pan towards the 'x' combat offset
            }
        }
        else // Pan back to the player when no enemy is in combat range
        {
            inCombat = false;
            if (offset.z >= orgOffset.z) // Set the cam offset to the original offset once the z value is reached or passed
            {
                offset.z = orgOffset.z;
            }
            else
            {
                offset.z += 20f * Time.deltaTime; // Pan towards the 'z' original offset
            }

            if (offset.y <= orgOffset.y) // Set the cam offset to the original offset once the y value is reached or passed
            {
                offset.y = orgOffset.y;
            }

            else
            {
                offset.y += -8f * Time.deltaTime; // Pan towards the 'y' original offset
            }

            if (offset.x <= orgOffset.x) // Set the cam offset to the original offset once the x value is reached or passed
            {
                offset.x = orgOffset.x;
            }
            else
            {
                offset.x += -6f * Time.deltaTime; // Pan towards the 'x' original offset
            }
        }
    }

}
