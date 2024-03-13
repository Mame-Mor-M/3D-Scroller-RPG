using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SunController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //sun = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0); // Adjust time of day by rotating sun
    }
}
