using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadManager : MonoBehaviour {
    
    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;

    int[] list = new int[15];
    int iterator = 0;
    bool go = false;
    bool blinking = false;

    float timer;
    public float interval_blink = 0.5F;

    // Use this for initialization
    void Start () {

        blue.state = Quad.State.NOFADE;

        red.state = Quad.State.NOFADE;
        
        yellow.state = Quad.State.NOFADE;

        green.state = Quad.State.NOFADE;

        timer = Time.realtimeSinceStartup;
        iterator = 0;
        go = false;

        for(int i = 0; i < 15; ++i)
        {
            if (i == 0)
                list[i] = 0;
            list[i] = Random.Range(0, 4);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (!go && Time.realtimeSinceStartup - timer > 5.0f)
        {
            go = true;
            timer = Time.realtimeSinceStartup;
        }

        if (go && !blinking)
        {
            switch (list[iterator])
            {
                case 0:                     //blue
                    blue.state = Quad.State.FADETOVIS;
                    blinking = true;
                    break;
                case 1:                     //red
                    red.state = Quad.State.FADETOVIS;
                    blinking = true;
                    break;
                case 2:                     //yellow
                    yellow.state = Quad.State.FADETOVIS;
                    blinking = true;
                    break;
                case 3:                     //green
                    green.state = Quad.State.FADETOVIS;
                    blinking = true;
                    break;
                default:
                    print("oh oh");
                    break;
            }
        }

        if(blue.state == Quad.State.FADETOINV)
        {
            blinking = false;
        }
        if (red.state == Quad.State.FADETOINV)
        {
            blinking = false;
        }
        if (green.state == Quad.State.FADETOINV)
        {
            blinking = false;
        }
        if (yellow.state == Quad.State.FADETOINV)
        {
            blinking = false;
        }





        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (red.sprite.enabled)
                red.sprite.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            red.sprite.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (yellow.sprite.enabled)
                yellow.sprite.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            yellow.sprite.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (green.sprite.enabled)
                green.sprite.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            green.sprite.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (blue.sprite.enabled)
                blue.sprite.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            blue.sprite.enabled = true;
        }*/

    }
}
