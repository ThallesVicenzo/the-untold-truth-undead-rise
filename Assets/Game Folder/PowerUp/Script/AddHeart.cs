using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    //life add
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {   
            audioSource.PlayOneShot(clip);
            other.GetComponent<Character>().life++;
            Destroy(transform.gameObject);
        }
    }
}
