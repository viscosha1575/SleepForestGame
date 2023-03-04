using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float health;
    public Image[] hearts;
    public int numHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float score;
    public GameObject scoreText;
    public Joystick joystick; 
    public Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sr;
    public bool faceRight = true;
    public float jumpForce = 7f;
    public GameObject deadMenu;
    public GameObject pauseMenu;
    public static bool GameIsCanvas;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
       GameIsCanvas = false;
}
    void FixedUpdate()
    {

        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite=emptyHeart;
            }
            else
            {
                hearts[i].sprite=fullHeart;
            }
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health == 3)
        {
            GameIsCanvas = true;
            Time.timeScale = 0f;
            deadMenu.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        Walk();
        Reflect();
        ChekingGround();
         score +=Time.timeScale;
        scoreText.GetComponent<Text>().text = " " + score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            health=health+1;
        }
    }
    void Walk()
    {
        for (int i = 0; i < 10000; i++)
        {

            moveVelocity.x = Input.GetAxis("Horizontal");
            moveVelocity.x = i;
            anim.SetFloat("MoveX", Mathf.Abs(moveVelocity.x));
            rb.velocity = new Vector2((moveVelocity.x * speed) / 200, rb.velocity.y);
            if (joystick.Horizontal >= .5f)
            {
                rb.velocity = new Vector2((moveVelocity.x * speed) / 150, rb.velocity.y);
            }

            else if (joystick.Horizontal == 0)
            {
                rb.velocity = new Vector2((moveVelocity.x * speed) / 200, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2((moveVelocity.x * speed) / 250, rb.velocity.y);
            }


        }
    }
    void Reflect()
    {
      if((moveVelocity.x > 0 && !faceRight)||(moveVelocity.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;

        }
    }
    
     void Jump()
    {
        if (onGround==true)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
    }

    void Pause()
        {
            GameIsCanvas = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius=0.5f;
    public LayerMask Ground;
    void ChekingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("OnGround",onGround);
    }

   
}
