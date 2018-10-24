using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCont : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight = true;
    public Text pointstext;

    public float speed;
    public float jumpforce;

    private AudioSource source;
    public AudioClip coinsound;
    public AudioClip jumpBoi;
    private float volLowRange = .5f;
    private float volHighRange = .6f;
    public static int points = 0;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    private Animator anim;
    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        print(points);
        SetCountText();
        print(pointstext);

    }

    

    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Run_Left", true);
        }
        else
        {
            anim.SetBool("Run_Left", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run_Right", true);
        }
        else
        {
            anim.SetBool("Run_Right", false);
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Boi_Jump");
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(jumpBoi);
        }

        if  (Input.GetKey(KeyCode.R))
        {
           points = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

        // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);



        //stuff I added to flip my character
        //if(facingRight == false && moveHorizontal > 0)
        //  {
        //    Flip();
        //  }
        // else if(facingRight == true && moveHorizontal < 0)
        //   {
        //      Flip();
        //  }

    }

    //void Flip()
    // {
    //  facingRight = !facingRight;
    //    Vector2 Scaler = transform.localScale;
    //     Scaler.x = Scaler.x * -1;
    //     transform.localScale = Scaler;
    // }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;


                // Audio stuff



            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin_Free"))
        {
            
            collision.gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinsound);
            points++;
            Debug.Log(points);
            SetCountText();
            
        }
    }

    void SetCountText()
    {
        pointstext.text = "Points: " + points.ToString();
    }
}


