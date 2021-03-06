using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    public static float characterVelocity = 3f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Animator animator;
    public NavMeshAgent enemy_ai;
    private SpriteRenderer player;
    Vector2 posLastFrame;


    private void Start()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0).normalized;
        enemy_ai.updateRotation = false;
        enemy_ai.updateUpAxis = false;
        player = GameObject.Find("player").GetComponent<SpriteRenderer>();
        Vector2 posLastFrame = transform.position;

    }
    // Update is called once per frame
    void Update()
    {

        float distance = transform.position.magnitude - GameObject.Find("potato fight").transform.position.magnitude;
        if (Mathf.Abs(distance) < 3)
        {
            enemy_ai.enabled = true;
            enemy_ai.SetDestination(GameObject.Find("potato fight").transform.position);


        }
        else
        {
            enemy_ai.enabled = false;
            movementPerSecond = movementDirection * characterVelocity;
            //move enemy: 
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y);

        }
        CheckHorizontal();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
        {
            movementDirection *= -1;
            animator.SetFloat("Horizontal", animator.GetFloat("Horizontal") * -1);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy3" || collision.gameObject.tag == "enemy2")
        {
            movementDirection *= -1;
            animator.SetFloat("Horizontal", animator.GetFloat("Horizontal") * -1);

        }
    }

    void CheckHorizontal()
    {
        if (transform.position.x > posLastFrame.x) // he's looking right
        {
            animator.SetFloat("Horizontal", 1);
        }

        if (transform.position.x < posLastFrame.x) // he's looking left
        {
            animator.SetFloat("Horizontal", -1);
        }
        posLastFrame = transform.position;
    }
}
