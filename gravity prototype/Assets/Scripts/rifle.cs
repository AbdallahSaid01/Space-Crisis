using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //got this code online cant explain but it controls the rifle with the mouse kek
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(-difference.y, -difference.x) * Mathf.Rad2Deg;
        spriteRenderer.flipX = true;

        // adjusting the rotation and flip on x and y based on gravity direction and facing direction of the weapon
        if (GetComponentInParent<potatoMan>().getGravityDown())
        {
            if (rotation_z < -90 || rotation_z > 90)
            {
                Vector3 normalPostion = new Vector3(1.28f, -0.95f, -0.1f);
                normalPostion.Normalize();
                spriteRenderer.flipY = true;
                transform.localPosition = normalPostion;
                transform.localRotation = Quaternion.Euler(0f, 0f, rotation_z);
            }
            else if (rotation_z <= 90 || rotation_z >= -90)
            {
                Vector3 flipedPosition = new Vector3(-1.28f, -0.95f, -0.1f);
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
                Vector3 normalPostion = new Vector3(1.28f, 0.95f, -0.1f);
                normalPostion.Normalize();
                spriteRenderer.flipY = false;
                transform.localPosition = normalPostion;
                transform.localRotation = Quaternion.Euler(0f, 0f, rotation_z);
            }
            else if (rotation_z <= 90 || rotation_z >= -90)
            {
                Vector3 flipedPosition = new Vector3(-1.28f, 0.95f, -0.1f);
                flipedPosition.Normalize();
                spriteRenderer.flipY = true;
                transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
                transform.localPosition = flipedPosition;
            }
        }
    }
}
