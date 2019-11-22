using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce;
    public int speed;
    public float checkRad;
    private float movement;

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
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetKeyDown(jumpKey)) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRad, GroundLayer);

        movement = Input.GetAxisRaw(inputAxis);

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }
}
