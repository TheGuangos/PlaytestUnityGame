using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour {
    
    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;
    
    public SpriteRenderer red_s;
    public SpriteRenderer yellow_s;
    public SpriteRenderer green_s;
    public SpriteRenderer blue_s;

    public Text counterText;
    public int counter_clicks;
    float timer;
    public float interval_blink = 0.5F;

    // Use this for initialization
    void Start () {

        blue.state = Quad.State.NOFADE;
        blue.sprite = blue_s;

        red.state = Quad.State.NOFADE;
        red.sprite = red_s;
        
        yellow.state = Quad.State.NOFADE;
        yellow.sprite = yellow_s;

        green.state = Quad.State.NOFADE;
        green.sprite = green_s;

        timer = Time.realtimeSinceStartup;
        SetText();
        counter_clicks = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
        }
    }

    void SetText()
    {
        counterText.text = "Counter: " + counter_clicks.ToString();
    }
}
