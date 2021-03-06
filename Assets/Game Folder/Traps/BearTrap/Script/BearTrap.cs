using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    Transform player;
    public Transform skin;
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
            audioSource.PlayOneShot(clip);
            skin.GetComponent<Animator>().Play("Stuck");
            other.transform.position = transform.position;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<PlayerControler>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);
            other.GetComponent<Rigidbody2D>().mass = 100;
            GetComponent<BoxCollider2D>().enabled = false;
            player = other.transform;
            other.GetComponent<PlayerControler>().enabled = false;
            Invoke("ReleasePlayer", 3);
        }
    }

    void ReleasePlayer()
    {
        player.GetComponent<PlayerControler>().enabled = true;
        player.GetComponent<Rigidbody2D>().mass = 1.206975f;
    }
}
