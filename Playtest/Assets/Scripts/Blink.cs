using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    SpriteRenderer white;
    bool test;
    Color tmp;
    // Use this for initialization
	void Start () {
        white = GetComponent<SpriteRenderer>();
        test = false;
        tmp = white.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            test = !test;
        }

        if (test)
        {
            white.color = tmp;
            tmp.a = 0.0f;
        }
        else
        {
            white.color = tmp;
            tmp.a = 0.9f;
        }
	}
}
