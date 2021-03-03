using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDoorHit : MonoBehaviour
{
    int lifeChange;
    public Transform lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        lifeChange = GetComponent<Character>().life;
    }

    // Update is called once per frame
    void Update()
    {
            if (lifeChange != GetComponent<Character>().life)
            {
                lifeChange = GetComponent<Character>().life;
                GetComponent<Character>().skin.GetComponent<Animator>().Play("LittleDoorHit");
            }

            if (GetComponent<Character>().life <= 0)
            {
                Destroy(transform.gameObject);
            }

            lifeBar.localScale = new Vector3((1 * GetComponent<Character>().life) / 10f, 1, 1);  
    }

}
