using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;
    public Transform skin;
    //life add
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {   
            GetComponent<AudioSource>().PlayOneShot(clip);
            skin.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<Character>().life++;
            Destroy(transform.gameObject, 0.3f);
        }
    }
}
