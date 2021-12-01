using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public static bool hasKey;


    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hasKey = true;
            Destroy(gameObject);
        }
        
        
    }
}
