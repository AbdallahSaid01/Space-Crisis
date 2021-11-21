using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    private static bool enable_pull_mod = false;
    private static bool enable_push_mod = false;
    private static bool enable_teleport_mod = false;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            enable_teleport_mod = true;
            print("tele mod " + enable_teleport_mod);
        }
        if (enable_teleport_mod)
        {
            enable_teleport_mod = false;
            GameObject.Find("potato fight").transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enable_pull_mod)
        {
            enable_pull_mod = false;
            enable_push_mod = false;
            Vector2 player_hori = new Vector2(GameObject.Find("player").transform.position.x, GameObject.Find("player").transform.position.y);
            Vector2 col_hori = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((player_hori - col_hori) * 100);
        }
        else if (enable_push_mod)
        {
            enable_pull_mod = false;
            enable_pull_mod = false;
            Vector2 player_hori = new Vector2(GameObject.Find("player").transform.position.x, GameObject.Find("player").transform.position.y);
            Vector2 col_hori = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((col_hori - player_hori) * 100);
        }

        Destroy(gameObject);
    }

    public void set_pull_mod(bool mod)
    {
        enable_pull_mod = mod;
    }

    public void set_push_mod(bool mod)
    {
        enable_push_mod = mod;
    }

}
