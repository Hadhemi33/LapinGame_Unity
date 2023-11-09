using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Movement : MonoBehaviour
{
    public float speed,jumpforce;
    Rigidbody2D rb;
    SpriteRenderer spr;
    float Hmove;
    public bool jumping, isGrounded;
    Animator anim;
    AudioSource source;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("je suis la fct start");
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        jumping = false;
        isGrounded = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Hmove = Input.GetAxis("Horizontal");
        //Debug.Log(Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           jumping = true;

        }
       FlipPerso();

        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(0, 0.1f, 0);
        //}

    }
    private void FixedUpdate()
    {
        //Debug.Log(Time.deltaTime);
        //Debug.Log(Hmove);
        rb.velocity = new Vector2(Hmove * speed,rb.velocity.y);

        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        if (jumping)
        {
            rb.AddForce(Vector2.up * jumpforce);
            jumping = false;
            isGrounded= false;

        }

        if (isGrounded)
        {
            anim.SetFloat("walk", Mathf.Abs(rb.velocity.x));
            anim.SetFloat("jump", 0);
        }else
        {
            anim.SetFloat("jump", Mathf.Abs(rb.velocity.y));

        }

    }
    void FlipPerso()
    {
        if (Hmove < 0 ) {
            spr.flipX = true;
        }else
        {
            spr.flipX = false;

        }
    }
}
