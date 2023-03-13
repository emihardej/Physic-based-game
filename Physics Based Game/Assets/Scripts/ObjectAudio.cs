using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAudio : MonoBehaviour
{
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //Plays audio sound effect for objects that hit the floor
    void OnCollisionEnter(Collision collision)
    {   
        if (collision.collider.tag == "Floor"){
            audioSource.Play();
        }
    }
}
