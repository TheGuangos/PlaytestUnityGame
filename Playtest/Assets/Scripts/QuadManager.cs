using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour {
    
    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;

    int[] list = new int[15];
    int iterator = 0;
    bool go = false;
    bool blinking = false;


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

        SetText();
        counter_clicks = 0;

        iterator = 0;
        go = false;

        for(int i = 0; i < 15; ++i)
        {
            list[i] = Random.Range(0, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
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
                    counter_clicks++;
                    SetText();
                    break;
                case 1:                     //red
                    red.state = Quad.State.FADETOVIS;
                    blinking = true;
                    iterator++;
                    counter_clicks++;
                    SetText();
                    break;
                case 2:                     //yellow
                    yellow.state = Quad.State.FADETOVIS;
                    blinking = true;
                    iterator++;
                    counter_clicks++;
                    SetText();
                    break;
                case 3:                     //green
                    green.state = Quad.State.FADETOVIS;
                    blinking = true;
                    iterator++;
                    counter_clicks++;
                    SetText();
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

    void SetText()
    {
        counterText.text = "Counter: " + counter_clicks.ToString();
    }
}
