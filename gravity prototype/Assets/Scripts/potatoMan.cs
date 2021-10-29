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
    private bool isJumping;
    private bool gravityDown;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        isJumping = false;
        gravityDown = true;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, 0.0f);
        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;
        if(direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && gravityDown)
        {
            rigidbody2d.AddForce(Vector2.up * jumpForce);
            isJumping = true;
        }
        if(Input.GetKeyDown(KeyCode.S) &&  gravityDown)
        {
            rigidbody2d.AddForce(Vector2.down * downForce);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gravityDown)
        {
            rigidbody2d.AddForce(Vector2.down * jumpForce );
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && !gravityDown)
        {
            rigidbody2d.AddForce(Vector2.up * downForce);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rigidbody2d.gravityScale *= -1;
            if (gravityDown)
                gravityDown = false;
            else if (!gravityDown)
                gravityDown = true;
        }

        if (gravityDown)
            spriteRenderer.flipY = false;
        else if (!gravityDown)
            spriteRenderer.flipY = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            isJumping = false;
    }

    public bool getGravityDown()
    {
        return gravityDown;
    }

}
