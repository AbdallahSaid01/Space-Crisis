using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (key.hasKey == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                key.hasKey = false;
            }
        }
            
    }
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

}