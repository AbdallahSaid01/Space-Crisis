using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Animator anim;
    public static bool advance = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (key.hasKey == true)
            {
                anim.SetBool("hasKey", true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E) && key.hasKey == true)
        {
            advance = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            key.hasKey = false;
        }
    }
    
}