using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public Transform[] bat;

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
            foreach(Transform obj in bat)
            {
                obj.GetComponent<BatControler>().enabled = true;
                obj.GetComponent<BatControler>().player = other.transform;
            }
        }            
    }


}

