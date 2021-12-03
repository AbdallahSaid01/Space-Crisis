using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public Animator anim;
    private float nextActionTime = 0.0f;
    public float period = 5f;
    bool lazer1;
    // Start is called before the first frame update
    void Start()
    {
        lazer1 = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            if (lazer1 == false)
            {
                anim.SetBool("lazer", true);
                lazer1 = true;
              //  Debug.Log("false->true");
            }
            else
            {
                anim.SetBool("lazer", false);
                lazer1 = false;
              // Debug.Log("true->false");
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lazer1 == true && collision.gameObject.name == "potato fight")
        {
            GameObject.Find("potato fight").GetComponent<potatoMan>().take_damage(2);
            //Debug.Log("damage");
            
        }
    }
}
