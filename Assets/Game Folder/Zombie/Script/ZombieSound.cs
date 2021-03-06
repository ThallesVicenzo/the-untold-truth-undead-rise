using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    //zombie walk sound
    public void SoundPlay()
    {
        audioSource.PlayOneShot(clip);    
    }









}
