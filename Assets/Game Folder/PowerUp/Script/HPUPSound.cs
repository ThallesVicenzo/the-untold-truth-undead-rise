using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUPSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
        }    
    }
}
