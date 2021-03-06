using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap2 : MonoBehaviour
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
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().PlayerDamage(1);
        }
    }
    
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
