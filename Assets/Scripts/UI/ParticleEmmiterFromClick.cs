using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmmiterFromClick : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioClip sound;


    private void OnMouseDown()
    {
        Debug.Log("Press MOuse Frame");
        particleSystem.Play();
        if(sound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}
