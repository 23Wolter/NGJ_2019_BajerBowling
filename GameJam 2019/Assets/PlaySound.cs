using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyplayed = false;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    
    void OnTriggerEnter()
    {
       if ((!alreadyplayed) && Input.GetButton("Fire1"))
        {

            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyplayed = true;
            
        } 
    }
}
