using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<potatoMan>().flipGravityDown();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<potatoMan>().flipGravityDown();
    }
}
