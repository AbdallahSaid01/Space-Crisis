using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    //private bool facingRight = true;

    private void Start()
    {
        //GameObject.Find("player").transform.Rotate(0f, 180f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 difference = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        difference.Normalize();
        transform.up = difference;
    }

    


}
