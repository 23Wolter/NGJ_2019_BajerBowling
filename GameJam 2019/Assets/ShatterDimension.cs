using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterDimension : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("o")) {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody; 
        }
    }
}
