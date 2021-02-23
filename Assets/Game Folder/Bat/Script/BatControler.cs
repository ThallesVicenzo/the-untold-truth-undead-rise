using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControler : MonoBehaviour
{
    public Transform Player;

    public float attackTime;

    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Character>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 5;
            this.enabled = false;
        }
        if(Vector2.Distance(transform.position, Player.GetComponent<CapsuleCollider2D>().bounds.center) > 1f)
        {
            attackTime = 0;            
            transform.position = Vector2.MoveTowards(transform.position, Player.position, 2f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;
            if(attackTime >= 1)
            {
                attackTime = 0;
                Player.GetComponent<Character>().life--;
            }            
        }

    }
}
