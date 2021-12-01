using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public Rigidbody2D rb;
    private static bool enable_push_mod = false;
    private static bool enable_teleport_mod = false;
    private static Slider push_bar;
    private static Slider teleport_bar;
    private static bool isPushFull = true;
    private static bool isTeleFull = true;

    public GameObject teleport_effect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        push_bar = GameObject.Find("Push Bar").GetComponent<Slider>();
        teleport_bar = GameObject.Find("Teleport Bar").GetComponent<Slider>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && teleport_bar.value > 0 && isTeleFull)
        {
            enable_teleport_mod = true;
            print("tele mod " + enable_teleport_mod);
        }
        if (enable_teleport_mod)
        {
            enable_teleport_mod = false;
            GameObject.Find("potato fight").transform.position = gameObject.transform.position;
            Destroy(gameObject);
            Instantiate(teleport_effect, GameObject.Find("potato fight").transform.position, GameObject.Find("potato fight").transform.rotation);
            teleport_bar.value -= 5;

            if(teleport_bar.value < 0.01)
            {
                isTeleFull = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enable_push_mod && push_bar.value > 0 && isPushFull && collision.gameObject.tag != "GravityFlipField")
        {
            enable_push_mod = false;
            Vector2 player_hori = new Vector2(GameObject.Find("player").transform.position.x, GameObject.Find("player").transform.position.y);
            Vector2 col_hori = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            push_bar.value -= 2;
            GameObject.Find("player").GetComponent<SpriteRenderer>().color = Color.white;
            
            if(push_bar.value < 0.01)
            {
                print("Push false");
                isPushFull = false;
            }
                collision.gameObject.GetComponent<Rigidbody2D>()?.AddForce((col_hori - player_hori) * 300);  
        }
        if(collision.gameObject.tag != "GravityFlipField")
            Destroy(gameObject);
    }
    public void set_push_mod(bool mod)
    {
        enable_push_mod = mod;
    }

    public static bool getIsPushFull()
    {
        return isPushFull;
    }

    public static bool getIsTeleFull()
    {
        return isTeleFull;
    }

    public static void setIsPushFull(bool full)
    {
        isPushFull = full;
    }

    public static void setIsTeleFull(bool full)
    {
        isTeleFull = full;
    }
}
