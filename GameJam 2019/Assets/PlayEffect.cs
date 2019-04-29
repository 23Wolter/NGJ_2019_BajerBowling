using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    private AudioSource source; 
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>(); 
    }

    void OnCollisionEnter(Collision col) {
        source.Play(); 
    }
}
