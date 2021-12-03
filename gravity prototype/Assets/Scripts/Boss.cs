using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public NavMeshAgent boss_ai;
    private float cooldown_1 = 3f;
    private Vector3 follow;

    public Transform firepoint_mouth;
    public Transform firepoint_eye;

    public GameObject bullet_prefab;
    public GameObject laser_prefab;
    public GameObject impact_effect;

    private Slider health_bar;
    public GameObject dying_points;
    private Transform[] child;
    private bool use_laser = false;
    // Start is called before the first frame update
    void Start()
    {
        boss_ai.updateRotation = false;
        boss_ai.updateUpAxis = false;

        health_bar = GameObject.Find("Boss Bar").GetComponent<Slider>();
        health_bar.value = 50;

        child = dying_points.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown_1 -= Time.deltaTime;
        follow = new Vector3(GameObject.Find("player").transform.position.x, GameObject.Find("FollowPoint").transform.position.y, 0);
        boss_ai.SetDestination(follow);
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
            shoot_projectiles();
        }
        if(health_bar.value % 10 == 0 && health_bar.value < 50 && use_laser)
        {
            boss_ai.enabled = false;
            shoot_laser();
        }
        else if(health_bar.value == 0)
        {
            die();
        }
        use_laser = false;
    }

    void shoot_projectiles()
    {
        Instantiate(bullet_prefab, firepoint_mouth.position, firepoint_mouth.rotation);
    }

    void shoot_laser()
    {
        Instantiate(laser_prefab, firepoint_eye.position, firepoint_eye.rotation);
    }

    public void take_damage(int dmg)
    {
        use_laser = true;
        health_bar.value -= dmg;
    }

    void die()
    {
        foreach(Transform baby in child)
        {
            Instantiate(impact_effect, baby.gameObject.transform.position, baby.gameObject.transform.rotation);
        }
        Destroy(gameObject);
    }
}
