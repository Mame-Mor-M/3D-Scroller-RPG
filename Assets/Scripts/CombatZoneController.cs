using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZoneController : MonoBehaviour
{
    public CameraController cam;
    public PlayerController player;

    public bool leftCombat;
    public bool rightCombat;
    public bool centerCombat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Combat Zone"))
        {
            leftCombat = true;
            rightCombat = false;
            centerCombat = false;
        }

        else if (other.CompareTag("Right Combat Zone"))
        {
            rightCombat = true;
            leftCombat = false;
            centerCombat = false;
        }

        else if (other.CompareTag("Center Combat Zone"))
        {
            centerCombat = true;
            rightCombat = false;
            leftCombat = false;
        }
        else
        {
            leftCombat=false;
            rightCombat=false;
            centerCombat=false;
        }
    }
}
