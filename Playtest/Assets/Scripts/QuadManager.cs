using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadManager : MonoBehaviour {

    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject green;

    private SpriteRenderer blue_s;
    private SpriteRenderer red_s;
    private SpriteRenderer yellow_s;
    private SpriteRenderer green_s;

    // Use this for initialization
    void Start () {
        red_s = red.GetComponentInChildren<SpriteRenderer>();
        blue_s = blue.GetComponentInChildren<SpriteRenderer>();
        green_s = green.GetComponentInChildren<SpriteRenderer>();
        yellow_s = yellow.GetComponentInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (red_s.enabled)
                red_s.enabled = false;
            else
                red_s.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (yellow_s.enabled)
                yellow_s.enabled = false;
            else
                yellow_s.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (green_s.enabled)
                green_s.enabled = false;
            else
                green_s.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (blue_s.enabled)
                blue_s.enabled = false;
            else
                blue_s.enabled = true;
        }

    }
}
