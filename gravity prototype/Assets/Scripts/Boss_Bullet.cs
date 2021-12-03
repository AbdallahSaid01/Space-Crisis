using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss_Bullet : MonoBehaviour
{
    public float speed = 60f;
    public Rigidbody2D rb;
    public GameObject bullet_inpact_prefab;
    private float scaleFactor;
    private bool fromMouth = true;
    private Vector3 target_pos;
    private Quaternion target_rot;
    // Start is called before the first frame update
    void Start()
    {
        print("Hello");
        if(transform.position == GameObject.Find("Firepoint 1").transform.position)
        {
            rb.velocity = transform.right * speed;
            fromMouth = true;
            print("Here");
        }
        else
        {
            Vector3 rotate;
            fromMouth = false;
            float distance = GameObject.Find("player").transform.position.x - GameObject.Find("Boss").transform.position.x;
            if (distance > 0)
            {
                print("Pos");
                rotate = new Vector3(0, -90, 0);
                transform.Rotate(rotate);
                scaleFactor = Time.deltaTime;
            }
            else
            {
                print("Neg");
                rotate = new Vector3(0, -270, 0);
                transform.Rotate(rotate);
                scaleFactor = -Time.deltaTime;
            }
            target_pos = GameObject.Find("player").transform.position;
            target_rot = GameObject.Find("player").transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!fromMouth)
        {
            Vector3 newScale = transform.localScale;
            newScale.x += scaleFactor * 4;
            transform.localScale = newScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "potato fight")
        {
            GameObject.Find("potato fight").GetComponent<potatoMan>().take_damage(5);
            Instantiate(bullet_inpact_prefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        else if(!collision.gameObject.name.Contains("Bullet"))
        {
            Instantiate(bullet_inpact_prefab, target_pos, target_rot);
            GameObject.Find("Boss").GetComponent<NavMeshAgent>().enabled = true;
        }
        Destroy(gameObject);

    }
}
