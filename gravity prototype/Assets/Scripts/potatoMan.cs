using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potatoMan : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float downForce;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2d;
    //isjumping used to to lock the number of jumps to 2
    private int isJumping;
    // bool gravitydown is true when gravity is down or -1 on the y axis and false when gravity is up or 1 on the y axis
    private bool gravityDown;
    public Animator anim;
    private bool facingRight = false;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        isJumping = 0;
        gravityDown = true;
        
    }
    
    private void Update()
    {
        //getting user input by reassigning transform.position
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, 0.0f);
        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;
        anim.SetFloat("running", Mathf.Abs(horizontal));

        //flipping character sprite based on the direction it is walking
        if (direction.x > 0 && facingRight == false)
        {
            //spriteRenderer.flipX = true;
            OrientXAxis();
        }
        else if (direction.x < 0 && facingRight == true)
        {
            //spriteRenderer.flipX = false;
            OrientXAxis();
        }

        //changing direction of jump force based on gravity direction
        if (Input.GetKeyDown(KeyCode.Space) && gravityDown)
        {
            //using isJumping to lock the number of jumps to 2
            if (isJumping < 2)
            {
                rigidbody2d.AddForce(Vector2.up * jumpForce);
                isJumping += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !gravityDown)
        {
            if (isJumping < 2)
            {
                rigidbody2d.AddForce(Vector2.down * jumpForce);
                isJumping += 1;
            }
        }

        //changing direction of slam down force based on gravity direction
        if (Input.GetKeyDown(KeyCode.S) && gravityDown)
        {
            rigidbody2d.AddForce(Vector2.down * downForce);
        }
        else if (Input.GetKeyDown(KeyCode.S) && !gravityDown)
        {
            rigidbody2d.AddForce(Vector2.up * downForce);
        }

        //switching gravity of the rigidbody
        if (Input.GetKeyDown(KeyCode.E))
        {
            rigidbody2d.gravityScale *= -1;
            if (gravityDown)
                gravityDown = false;
            else if (!gravityDown)
                gravityDown = true;
        }

        //flipping sprite of character on y axis based on gravity direction
        if (gravityDown)
            spriteRenderer.flipY = false;
        else if (!gravityDown)
            spriteRenderer.flipY = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //when colliding to the ground making the jump counter = 0
        if (collision.gameObject.tag == "ground")
            isJumping = 0;
    }

    //using this getter to get the gravity in the rifle script
    public bool getGravityDown()
    {
        return gravityDown;
    }
    void OrientXAxis()
    {
        facingRight = !facingRight;
        GameObject.Find("player").transform.Rotate(0f, 180f, 0f);
        
    }
}
