using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour {
    
    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;
<<<<<<< HEAD
    
    public SpriteRenderer red_s;
    public SpriteRenderer yellow_s;
    public SpriteRenderer green_s;
    public SpriteRenderer blue_s;
=======

    int[] list = new int[15];
    int iterator = 0;
    bool go = false;
    bool blinking = false;
>>>>>>> d2595150837698a3fe9e69cb61ce1ecade09965b

    public Text counterText;
    public int counter_clicks;
    float timer;
    public float interval_blink = 0.5F;

    // Use this for initialization
    void Start () {

        blue.state = Quad.State.NOFADE;

        red.state = Quad.State.NOFADE;
        
        yellow.state = Quad.State.NOFADE;

        green.state = Quad.State.NOFADE;

        timer = Time.realtimeSinceStartup;
<<<<<<< HEAD
        SetText();
        counter_clicks = 0;
=======
        iterator = 0;
        go = false;

        for(int i = 0; i < 15; ++i)
        {
            list[i] = Random.Range(0, 4);
        }
>>>>>>> d2595150837698a3fe9e69cb61ce1ecade09965b
    }
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.UpArrow))
=======

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
                    iterator++;
                    break;
                case 1:                     //red
                    red.state = Quad.State.FADETOVIS;
                    blinking = true;
                    iterator++;
                    break;
                case 2:                     //yellow
                    yellow.state = Quad.State.FADETOVIS;
                    blinking = true;
                    iterator++;
                    break;
                case 3:                     //green
                    green.state = Quad.State.FADETOVIS;
                    blinking = true;
                    iterator++;
                    break;
                default:
                    print("oh oh");
                    break;
            }
        }

        if (blinking)
        {
            if (blue.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
            if (red.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
            if (green.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
            if (yellow.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
        }

        if (iterator >= 15)
        {
            
            print("Se acabo el juego pisha");
            iterator = 0;
            for (int i = 0; i < 15; ++i)
            {
                list[i] = Random.Range(0, 4);
            }
        }





        /*if (Input.GetKeyDown(KeyCode.UpArrow))
>>>>>>> d2595150837698a3fe9e69cb61ce1ecade09965b
        {
            if (red.sprite.enabled)
                red.sprite.enabled = false;
            counter_clicks++;
            SetText();        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            red.sprite.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (yellow.sprite.enabled)
                yellow.sprite.enabled = false;
            counter_clicks++;
            SetText();        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            yellow.sprite.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (green.sprite.enabled)
                green.sprite.enabled = false;
            counter_clicks++;
            SetText();        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            green.sprite.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (blue.sprite.enabled)
                blue.sprite.enabled = false;
            counter_clicks++;
            SetText();        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            blue.sprite.enabled = true;
<<<<<<< HEAD
        }
    }
=======
        }*/
>>>>>>> d2595150837698a3fe9e69cb61ce1ecade09965b

    void SetText()
    {
        counterText.text = "Counter: " + counter_clicks.ToString();
    }
}
