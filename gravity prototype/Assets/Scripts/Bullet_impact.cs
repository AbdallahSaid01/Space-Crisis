using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_impact : MonoBehaviour
{
    private Animator anim;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Destroy(gameObject);
        }
    }
}
