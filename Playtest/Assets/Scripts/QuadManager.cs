using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadManager : MonoBehaviour {

    enum Stage
    {
        NONE,
        ITERATION,
        PLAYER
    }

    public AudioClip Do;
    public AudioClip Mi;
    public AudioClip Si;
    public AudioClip Sol;
    public AudioClip Start_fx;
    public AudioSource DoSource;
    public AudioSource MiSource;
    public AudioSource SiSource;
    public AudioSource SolSource;
    public AudioSource StartSource;

    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;

    public GameObject go_text;
    bool go_wait = false;
    float go_timer = 0.0f;

    List<int> patron;
    int iterator = 0;
    int iterator_player = 0;
    Stage stage = Stage.NONE;
    bool blinking = false;
    int level = 1;

    public Text counterText;
    public int counter_clicks = 0;
    float timer = 0.0F;
    public float interval_blink = 0.5F;

    // Use this for initialization
    void Start () {

        StartSource.clip = Start_fx;

        timer = Time.realtimeSinceStartup;

        SetText();
        counter_clicks = 0;

        go_text.SetActive(false);

        iterator = 0;
        iterator_player = 0;
        stage = Stage.NONE;
        go_wait = false;
        patron = new List<int>();
        patron.Add(Random.Range(0, 4));
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage)
        {
            case Stage.NONE:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    stage = Stage.ITERATION;
                    timer = Time.realtimeSinceStartup;
                    go_text.SetActive(false);
                    StartSource.Play();
                    blinking = false;
                }
                break;
            case Stage.ITERATION:
                if (!blinking)
                {
                    switch (patron[iterator])
                    {
                        case 0:                     //blue
                            blue.state = Quad.State.FADETOVIS;
                            DoSource.clip = Do;
                            DoSource.Play();
                            break;
                        case 1:                     //red
                            red.state = Quad.State.FADETOVIS;
                            MiSource.clip = Mi;
                            MiSource.Play();
                            break;
                        case 2:                     //yellow
                            yellow.state = Quad.State.FADETOVIS;
                            SiSource.clip = Si;
                            SiSource.Play();
                            break;
                        case 3:                     //green
                            green.state = Quad.State.FADETOVIS;
                            SolSource.clip = Sol;
                            SolSource.Play();
                            break;
                        default:
                            print("oh oh");
                            break;
                    }
                    blinking = true;
                    iterator++;
                    counter_clicks++;
                    SetText();
                }
                else
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

                if (iterator >= patron.Count && !blinking)
                {
                    print("te toca chaval");
                    stage = Stage.PLAYER;
                    go_text.SetActive(true);
                    go_wait = true;
                    go_timer = Time.realtimeSinceStartup;
                }
                break;
            case Stage.PLAYER:

                if (go_wait && Time.realtimeSinceStartup - go_timer >= 1.5f)
                {
                    go_wait = false;
                    go_text.SetActive(false);
                    iterator_player = 0;
                }
                else if (!go_wait)
                {
                    if(Input.GetKeyDown(KeyCode.UpArrow))
                        if(patron[iterator_player] == 1)
                        {
                            //succes
                            iterator_player++;
                        }
                        else
                        {
                            //fail
                        }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                        if (patron[iterator_player] == 3)
                        {
                            //succes
                            iterator_player++;
                        }
                        else
                        {
                            //fail
                        }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                        if (patron[iterator_player] == 2)
                        {
                            //succes
                            iterator_player++;
                        }
                        else
                        {
                            //fail
                        }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                        if (patron[iterator_player] == 0)
                        {
                            //succes
                            iterator_player++;
                        }
                        else
                        {
                            //fail
                        }
                }
                if (iterator_player >= patron.Count)
                {
                    iterator = 0;
                    iterator_player = 0;
                    stage = Stage.ITERATION;
                    level++;
                    patron.Add(Random.Range(0, 4));
                }
                break;
            default:
                break;
        }
    }

    void SetText()
    {
        counterText.text = "Counter: " + counter_clicks.ToString();
    }
}