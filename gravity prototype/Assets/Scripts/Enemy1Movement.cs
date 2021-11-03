using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public static float characterVelocity = 1f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0).normalized;
        //movementPerSecond = movementDirection * characterVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        movementPerSecond = movementDirection * characterVelocity;
        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y);

        // For the movement animations
        animator.SetFloat("Horizontal", movementDirection.x);
        //animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementPerSecond.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stop")
        {
            movementDirection.x *= -1;
        }
    }
}
