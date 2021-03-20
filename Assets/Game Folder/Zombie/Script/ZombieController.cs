using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform skin;
    public Transform dead;
    public Transform player;
    Vector3 moveDirecton;
    Rigidbody2D rb;
    public float zombieSpeed = 0.4f;
    public float zombieRise;
    public AudioSource audioSource;
    public AudioClip deadsound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(deadsound);
            GetComponent<CapsuleCollider2D>().enabled = false;
            dead.GetComponent<BoxCollider2D>().enabled = true;
            skin.GetComponentInChildren<CapsuleCollider2D>().enabled = false;
            rb.mass = 1000;
            this.enabled = false;
        }

        skin.GetComponent<Animator>().SetFloat("playerDistance", Vector2.Distance(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center));
        if (Vector2.Distance(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center) < 10)
        {
            zombieRise = zombieRise + Time.deltaTime;
            if (zombieRise > 1 && this.enabled)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CapsuleCollider2D>().enabled = true;
                skin.GetComponentInChildren<CapsuleCollider2D>().enabled = true;
                skin.GetComponent<Animator>().SetBool("isWalking", true);
                skin.transform.localScale = new Vector3(player.transform.position.x > transform.position.x ? -1f : 1f, 1f, 1f);
            }
        }

        if (skin.GetComponent<Animator>().GetBool("isWalking"))
        {
            moveDirecton = new Vector3(player.transform.position.x - transform.position.x, transform.position.y, 0);
            moveDirecton.Normalize();
            rb.velocity = moveDirecton * zombieSpeed;
        }
    }
}
