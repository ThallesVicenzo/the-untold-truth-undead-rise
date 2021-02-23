using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
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
        if(other.tag == "Player")
        {   
            //other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //other.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
            other.GetComponent<Character>().life--;
        }    
    }
}
