using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger1 : MonoBehaviour
{
    public Transform [] zombie;
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
            foreach(Transform obj in zombie)
            {
                obj.GetComponent<ZombieController>().enabled = true;
                obj.GetComponent<ZombieController>().player = other.transform;
            }
        }            
    }
}
