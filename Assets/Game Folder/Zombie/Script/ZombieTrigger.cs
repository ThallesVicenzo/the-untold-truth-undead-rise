using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public Transform [] Zombie;
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
            foreach(Transform obj in Zombie)
            {
                obj.GetComponent<ZombieController>().enabled = true;
                obj.GetComponent<ZombieAttack>().enabled = true;
                obj.GetComponent<Animation>().enabled = true;
            }
            
        }    
    }
}
