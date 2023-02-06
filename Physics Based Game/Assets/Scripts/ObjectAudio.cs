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
    void OnCollisionEnter(Collision collision)
    {   
        if (collision.collider.tag == "Floor"){
            audioSource.Play();
        }
    }
}
