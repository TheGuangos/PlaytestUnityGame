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

    enum state
    {
        NOFADE,
        FADETOINV,
        IDLE,
        FADETOVIS
    }

    private state blue_state = state.NOFADE;
    private state red_state = state.NOFADE;
    private state green_state = state.NOFADE;
    private state yellow_state = state.NOFADE;

    float timer;
    public float interval_blink = 0.5F;

    // Use this for initialization
    void Start () {
        red_s = red.GetComponentInChildren<SpriteRenderer>();
        blue_s = blue.GetComponentInChildren<SpriteRenderer>();
        green_s = green.GetComponentInChildren<SpriteRenderer>();
        yellow_s = yellow.GetComponentInChildren<SpriteRenderer>();

        timer = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {
        
        switch(red_state){
            case state.NOFADE:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    red_state = state.FADETOINV;

                }
                break;
            case state.IDLE:
                break;
            case state.FADETOINV:
                break;
            case state.FADETOVIS:
                break;
        }

        switch (blue_state)
        {
            case state.NOFADE:
                break;
            case state.IDLE:
                break;
            case state.FADETOINV:
                break;
            case state.FADETOVIS:
                break;
        }

        switch (green_state)
        {
            case state.NOFADE:
                break;
            case state.IDLE:
                break;
            case state.FADETOINV:
                break;
            case state.FADETOVIS:
                break;
        }

        switch (yellow_state)
        {
            case state.NOFADE:
                break;
            case state.IDLE:
                break;
            case state.FADETOINV:
                break;
            case state.FADETOVIS:
                break;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (red_s.enabled)
                red_s.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            red_s.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (yellow_s.enabled)
                yellow_s.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
        
            yellow_s.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (green_s.enabled)
                green_s.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            green_s.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (blue_s.enabled)
                blue_s.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            blue_s.enabled = true;
        }

    }
}
