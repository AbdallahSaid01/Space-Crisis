using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : MonoBehaviour
{
    public NavMeshAgent boss_ai;
    private SpriteRenderer player;
    private bool chasePlayer = true;
    private float cooldown_1 = 3f;
    //private float cooldow
    private Vector3 follow;

    public Transform firepoint_mouth;
    public Transform firepoint_eye;

    public GameObject bullet_prefab;
    public GameObject laser_prefab;
    // Start is called before the first frame update
    void Start()
    {
        boss_ai.updateRotation = false;
        boss_ai.updateUpAxis = false;
        //boss_ai.updatePosition = false;
        player = GameObject.Find("player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown_1 -= Time.deltaTime;
        follow = new Vector3(GameObject.Find("player").transform.position.x, GameObject.Find("FollowPoint").transform.position.y, 0);
        //boss_ai.SetDestination(follow);
        firepoint_eye.LookAt(GameObject.Find("player").transform);

        float distance = GameObject.Find("player").transform.position.x - transform.position.x;
        if(distance > 0)
        {
            Vector3 right = new Vector3(1, 0, 0);
            transform.right = right;
        }
        else
        {
            Vector3 left = new Vector3(-1, 0, 0);
            transform.right = left;
        }

        if(cooldown_1 < 0.01)
        {
            cooldown_1 = 3;
            shoot_laser();
        }
    }

    void shoot_projectiles()
    {
        Instantiate(bullet_prefab, firepoint_mouth.position, firepoint_mouth.rotation);
    }

    void shoot_laser()
    {
        Instantiate(laser_prefab, firepoint_eye.position, firepoint_eye.rotation);
    }
}
