using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce;
    public int speed;
    public float checkRad;
    private float movement;
    private float scl;
    private bool isRight;

    [SerializeField]
    private Animator anim;

    public LayerMask GroundLayer;

    public KeyCode jumpKey;
    public string inputAxis;

    private Rigidbody2D rb;
    public Transform groundCheck;

    [SerializeField]
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scl = transform.localScale.x;
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetKeyDown(jumpKey)) {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("Jumping");
            //anim.SetBool("InAir", true);
        }

        if (movement == -1 && isRight)
        {
            transform.localScale = new Vector3(scl * -1, transform.localScale.y, 1);
            isRight = false;
        }
        else if (movement == 1 && !isRight)
        {
            transform.localScale = new Vector3(scl, transform.localScale.y, 1);
            isRight = true;
        }

        if(movement != 0 && isGrounded)
        {
            anim.SetBool("Running", true);
        } else
        {
            anim.SetBool("Running", false);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRad, GroundLayer);
        if(isGrounded)
        {
            anim.SetBool("InAir", false);
        } else
        {
            anim.SetBool("InAir", true);
        }

        movement = Input.GetAxisRaw(inputAxis);

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        
    }
}
