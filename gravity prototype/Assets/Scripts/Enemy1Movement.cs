using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy1Movement : MonoBehaviour
{
    public static float characterVelocity = 1f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Animator animator;
    public NavMeshAgent enemy_ai;
    private bool isFlipped = true;
    private SpriteRenderer player;
    
    
    private void Start()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0).normalized;
        enemy_ai.updateRotation = false;
        enemy_ai.updateUpAxis = false;
        player = GameObject.Find("player").GetComponent<SpriteRenderer>();
       
        
    }
    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.magnitude - GameObject.Find("potato fight").transform.position.magnitude;
        if (Mathf.Abs(distance) < 3)
        {
            enemy_ai.enabled = true;
            enemy_ai.SetDestination(GameObject.Find("potato fight").transform.position);
            if (player.flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            enemy_ai.enabled = false;
            movementPerSecond = movementDirection * characterVelocity;
            //move enemy: 
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y);

            // For the movement animations
            animator.SetFloat("Speed", movementPerSecond.magnitude);

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stop")
        {
            movementDirection *= -1;
            if(movementDirection.x < 0)
            {
                isFlipped = false;
            }
            else
            {
                isFlipped = true;
            }
            GetComponent<SpriteRenderer>().flipX = isFlipped;
        }
    }
}
