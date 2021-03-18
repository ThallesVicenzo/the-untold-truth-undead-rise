using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Transform boss;
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
        if(other.CompareTag("Enemy"))
        {
            boss = other.transform;
            other.transform.parent = transform;
            other.transform.localPosition = Vector3.zero;
        }
    }

    public void ReleaseBoss()
    {
        boss.parent = null;
    }
}
