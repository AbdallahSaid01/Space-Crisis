using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifle : MonoBehaviour
{
    public Transform riflePoint;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire_bullet();
        }
    }

    void fire_bullet()
    {
        Instantiate(bulletPrefab, riflePoint.position, riflePoint.rotation);
    }
}
