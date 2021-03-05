using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 vel;
    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip dashSound;


    public Transform floorCollider;
    public Transform skin;
    public float facingDirection;
    public int numeroCombo;
    public float tempoCombo;
    public float dashTime;

    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        }

        tempoCombo = tempoCombo + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && tempoCombo > 0.5f)
        {
            numeroCombo++;
            if(numeroCombo > 2)
            {
                numeroCombo = 1;
            }   
            tempoCombo = 0;
            skin.GetComponent<Animator>().Play("PlayerAtack" + numeroCombo);
                    if(numeroCombo == 1)
        {
            audioSource.PlayOneShot(attack1Sound);
        }
        if(numeroCombo == 2)
        {
            audioSource.PlayOneShot(attack2Sound);
        }
        if (tempoCombo >= 1)
        {
            numeroCombo = 0;
        }
        }
        //player mov
        if(Input.GetButtonDown("Jump") && floorCollider.GetComponent<FloorCollider>().canJump == true)
        {
            skin.GetComponent<Animator>().Play("PlayerJump");
            rb.velocity = Vector2.zero;
            floorCollider.GetComponent<FloorCollider>().canJump = false;
            rb.AddForce(new Vector2(0, 1000));
        }
        vel = new Vector2(Input.GetAxisRaw("Horizontal") *7f, rb.velocity.y);

        if ((Input.GetAxisRaw("Horizontal") != 0))
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1f, 1f);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
            facingDirection = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
        //end
        if(GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            rb.simulated = false;
        }

        dashTime = dashTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash");
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(skin.localScale.x * 1000, 0));
            audioSource.PlayOneShot(dashSound);
        }


    }

    private void FixedUpdate()
    {   
        if(dashTime > 0.5)
        {
            rb.velocity = vel;
        }
        
    }

}
