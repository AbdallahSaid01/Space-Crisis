using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss : MonoBehaviour
{
    public NavMeshAgent boss_ai;
    private bool isFlipped = true;
    private SpriteRenderer player;
    private bool chasePlayer = true;
    private float cooldown = 3f;
    private Vector3 rotation;
    private Vector3 follow;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(0, 180, 0);
        boss_ai.updateRotation = false;
        boss_ai.updateUpAxis = false;
        //boss_ai.updatePosition = false;
        player = GameObject.Find("player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        follow = new Vector3(GameObject.Find("player").transform.position.x, GameObject.Find("FollowPoint").transform.position.y, 0);
        boss_ai.SetDestination(follow);
    }
}
