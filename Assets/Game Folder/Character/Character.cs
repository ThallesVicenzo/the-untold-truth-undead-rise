using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {

            skin.GetComponent<Animator>().Play("Die");

        }
    }

    public void PlayerDamage(int value)
    {
        life = life - value;
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("CameraPlayerDamage");
    }
}
