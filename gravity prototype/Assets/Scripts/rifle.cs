using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifle : MonoBehaviour
{
    float rotation_z = 0;
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private bool push = false;
    // Update is called once per frame
    void Update()
    {
        //got this code online cant explain but it controls the rifle with the mouse kek
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        spriteRenderer.flipX = true;

        float cuurentRotation_z = Mathf.Atan2(-difference.y, -difference.x) * Mathf.Rad2Deg;
        if (rotation_z != cuurentRotation_z)
        {
            rotation_z = cuurentRotation_z;
            // adjusting the rotation and flip on x and y based on gravity direction and facing direction of the weapon
            if (GetComponentInParent<potatoMan>().getGravityDown())
            {
                if (rotation_z < -90 || rotation_z > 90)
                {
                    Vector3 normalPostion = new Vector3(9.28f, 6f, -0.1f);
                    normalPostion.Normalize();
                    spriteRenderer.flipY = true;
                    normalPostion.x *= 7;
                    transform.localPosition = normalPostion;
                    transform.localRotation = Quaternion.Euler(0f, 0f, rotation_z);
                }
                else if (rotation_z <= 90 || rotation_z >= -90)
                {
                    Vector3 flipedPosition = new Vector3(-9.28f, 6f, -0.1f);
                    flipedPosition.Normalize();
                    spriteRenderer.flipY = false;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
                    transform.localPosition = flipedPosition;
                }
            }
            else if (!GetComponentInParent<potatoMan>().getGravityDown())
            {
                if (rotation_z < -90 || rotation_z > 90)
                {
                    Vector3 normalPostion = new Vector3(9.28f, 0.95f, -0.1f);
                    normalPostion.Normalize();
                    spriteRenderer.flipY = false;
                    normalPostion.x *= 7;
                    transform.localPosition = normalPostion;
                    transform.localRotation = Quaternion.Euler(0f, 0f, rotation_z);
                }
                else if (rotation_z <= 90 || rotation_z >= -90)
                {
                    Vector3 flipedPosition = new Vector3(-9.28f, 0.95f, -0.1f);
                    flipedPosition.Normalize();
                    spriteRenderer.flipY = true;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
                    transform.localPosition = flipedPosition;
                }
            }
        }

        if (Input.mouseScrollDelta.y > 0f && Bullet.getIsPushFull())
        {
            GameObject.Find("player").GetComponent<SpriteRenderer>().color = Color.red;
            push = true;
            bulletPrefab.GetComponent<Bullet>().set_push_mod(push);
            print("push mod " + push);
            push = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            fire_bullet();
        }
    }
    void fire_bullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
