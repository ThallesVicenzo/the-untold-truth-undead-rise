using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 vel;


    public Transform floorCollider;
    public Transform skin;
    public float facingDirection;
    public int numeroCombo;
    public float tempoCombo;
    public float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        if (tempoCombo >= 1)
        {
            numeroCombo = 0;
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
