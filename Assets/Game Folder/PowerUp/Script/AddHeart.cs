using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{

    //life add
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {   
            other.GetComponent<Character>().life++;
            Destroy(transform.gameObject);
        }
    }
}
