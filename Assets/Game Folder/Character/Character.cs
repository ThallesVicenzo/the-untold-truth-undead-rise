using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;
    public Text HeartCountText;

    public AudioClip bossBattleMusic;
    public AudioClip youWin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0 && !transform.name.Equals("BossBrain"))
        {
            skin.GetComponent<Animator>().Play("Die");
        }
        if(transform.CompareTag("Player"))
        {
            HeartCountText.text = "x" + life.ToString();

            if(SceneManager.GetActiveScene().name.Equals("BossLevel"))
            {
                cam.GetComponent<Animator>().enabled = false;
                cam.GetComponent<Camera>().orthographicSize = 10.3f;
                cam.position = new Vector3(14, 5, -1);
                cam.parent = null;
                SceneManager.MoveGameObjectToScene(cam.gameObject, SceneManager.GetActiveScene());

                if(GameObject.Find("BossBrain").GetComponent<Character>().life > 0)
                {
                    if(cam.GetComponent<AudioSource>().clip != bossBattleMusic)
                    {
                        cam.GetComponent<AudioSource>().clip = bossBattleMusic;
                        cam.GetComponent<AudioSource>().Play();
                    }
                }
                else
                {
                    if(cam.GetComponent<AudioSource>().clip != null)
                        {
                            cam.GetComponent<AudioSource>().Stop();
                            cam.GetComponent<AudioSource>().clip = null;
                            cam.GetComponent<AudioSource>().PlayOneShot(youWin);
                        }
                }
                
            }
        }

        if(transform.name.Equals("BossBrain"))
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f, (life * 1.09f / 30));

            if(life <= 0)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                GameObject.Find("Player").GetComponent<PlayerControler>().enabled = false;
                GameObject.Find("Player").GetComponent<CapsuleCollider2D>().enabled = false;
                GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    
            }
        }
    }

    public void PlayerDamage(int value)
    {
        life = life - value;
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("CameraPlayerDamage");
        GetComponent<PlayerControler>().audioSource.PlayOneShot(GetComponent<PlayerControler>().damageSound, 0.5f);
    }
}
