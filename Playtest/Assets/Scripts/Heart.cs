using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private float scale = 1.0F;
    private bool inc = true;
    // Use this for initialization
    void Start()
    {
        scale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (inc)
        {
            scale += 0.01f;
        }
        else
        {
            scale -= 0.01f;
        }
        if (scale >= 1.2f || scale <= 1.0f)
        {
            inc = !inc;
        }

        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }
}
