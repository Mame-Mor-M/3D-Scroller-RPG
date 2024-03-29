using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OxygenController : MonoBehaviour
{
    [SerializeField] float totalOxygen;
    [SerializeField] float maxOxygen;
    [SerializeField] float oxygenDepletionRate;

    private bool onShip;

    void Update()
    {
        Debug.Log("Oxygen: " + totalOxygen);

        if (onShip)
        {
            totalOxygen += 1 * Time.deltaTime;
            if (totalOxygen >= maxOxygen)
            {
                totalOxygen = maxOxygen;
            }
        }

        else
        {
            totalOxygen -= oxygenDepletionRate * Time.deltaTime; 
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship")
        {
            onShip = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ship")
        {
            onShip = false;
        }
    }
}
