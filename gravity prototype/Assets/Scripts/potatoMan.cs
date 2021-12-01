using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private static Slider push_bar;
    private static Slider teleport_bar;

    private Slider health_bar;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        isJumping = 0;
        gravityDown = true;

        push_bar = GameObject.Find("Push Bar").GetComponent<Slider>();
        teleport_bar = GameObject.Find("Teleport Bar").GetComponent<Slider>();

        health_bar = GameObject.Find("Health Bar").GetComponent<Slider>();

        health_bar.value = 20;
        push_bar.value = 10;
        teleport_bar.value = 10;
    }

    private void Update()
    {
        //getting user input by reassigning transform.position
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, 0.0f);
        direction = direction.normalized;
        if (horizontal < -0.1f || horizontal > 0.1f)
            transform.Translate(direction * speed * Time.deltaTime);

        anim.SetFloat("running", Mathf.Abs(horizontal));

        //flipping character sprite based on the direction it is walking
        if (direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
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
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    flipGravityDown();
        //}

        //flipping sprite of character on y axis based on gravity direction
        if (gravityDown)
            spriteRenderer.flipY = false;
        else if (!gravityDown)
            spriteRenderer.flipY = true;

        if (teleport_bar.value != 10 && !Bullet.getIsTeleFull())
        {
            teleport_bar.value += Time.deltaTime;
            if (teleport_bar.value > 9.9)
            {
                Bullet.setIsTeleFull(true);
            }
        }
        if (push_bar.value != 10 && !Bullet.getIsPushFull())
        {
            print("Refilling push bar");
            push_bar.value += Time.deltaTime;
            if (push_bar.value > 9.9)
            {
                Bullet.setIsPushFull(true);
            }
        }
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

    public void flipGravityDown()
    {
        rigidbody2d.gravityScale *= -1;
        if (gravityDown)
            gravityDown = false;
        else if (!gravityDown)
            gravityDown = true;
    }

    //Taking damage
    public void take_damage(int dmg)
    {
        health_bar.value -= dmg;
    }
}
