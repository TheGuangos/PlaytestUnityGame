using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour {
    
    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;

    public GameObject go_text;
    bool go_wait = false;
    float go_timer = 0.0f;

    List<int> patron;
    int iterator = 0;
    bool go = false;
    bool blinking = false;
    int level = 1;

    public Text counterText;
    public int counter_clicks;
    float timer;
    public float interval_blink = 0.5F;

    // Use this for initialization
    void Start () {

        timer = Time.realtimeSinceStartup;

        SetText();
        counter_clicks = 0;

        go_text.SetActive(false);

        iterator = 0;
        go = false;
        patron = new List<int>();
        patron.Add(Random.Range(0, 4));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
                go = true;
                timer = Time.realtimeSinceStartup;
                go_text.SetActive(false);

        }

        if (go && !blinking && !go_wait)
        {
            switch (patron[iterator])
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
        else if(Time.realtimeSinceStartup - go_timer >= 1.5f && go_wait == true)
        {
            go_wait = false;
            go_text.SetActive(false);
        }

        if (blinking)
        {
            if (blue.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
            else if (red.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
            else if (green.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
            else if (yellow.state == Quad.State.COMPLETED)
            {
                blinking = false;
            }
        }

        if (iterator >= patron.Count)
        {
            print(patron);
            print("Next level chaval");

            go_text.SetActive(true);
            go_wait = true;
            go_timer = Time.realtimeSinceStartup;

            iterator = 0;
            level++;
            patron.Add(Random.Range(0, 4));
        }

    }



        /*if (Input.GetKeyDown(KeyCode.UpArrow))
>>>>>>> d2595150837698a3fe9e69cb61ce1ecade09965b
        {
            if (red.sprite.enab8led)
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