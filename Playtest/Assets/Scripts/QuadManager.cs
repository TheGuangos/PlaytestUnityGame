﻿using System.Collections;
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
    public AudioClip GameOver_fx;
    public AudioSource MusicSource;
  

    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;

    public GameObject go_text;
    bool go_wait = false;
    float go_timer = 0.0f;
    public GameObject perfect_text;
    bool perfect_wait = false;
    float perfect_timer = 0.0f;

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

        MusicSource.clip = Start_fx;

        timer = Time.realtimeSinceStartup;

        SetText();
        counter_clicks = 0;

        go_text.SetActive(false);
        perfect_text.SetActive(false);

        iterator = 0;
        iterator_player = 0;
        stage = Stage.NONE;
        go_wait = false;
        patron = new List<int>();
        patron.Add(Random.Range(0, 4));
        MusicSource.Play();
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
                            MusicSource.clip = Do;
                            MusicSource.Play();
                            break;
                        case 1:                     //red
                            red.state = Quad.State.FADETOVIS;
                            MusicSource.clip = Mi;
                            MusicSource.Play();
                            break;
                        case 2:                     //yellow
                            yellow.state = Quad.State.FADETOVIS;
                            MusicSource.clip = Si;
                            MusicSource.Play();
                            break;
                        case 3:                     //green
                            green.state = Quad.State.FADETOVIS;
                            MusicSource.clip = Sol;
                            MusicSource.Play();
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

                if (iterator >= patron.Count && !blinking) //when iterates all list
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
                    perfect_wait = true;
                }
                else if (!go_wait)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow)) //red
                    {
                        red.SetInvisible();
                        if (patron[iterator_player] == 1)
                        {
                            //succes
                            iterator_player++;
                            //MusicSource.clip = Mi;
                            //MusicSource.Play();
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                        }
                    }
                    else if(Input.GetKeyUp(KeyCode.UpArrow)) { red.SetVisible(); }

                    if (Input.GetKeyDown(KeyCode.RightArrow)) //green
                    {
                        green.SetInvisible();
                        if (patron[iterator_player] == 3)
                        {
                            //succes
                            iterator_player++;
                            //MusicSource.clip = Sol;
                            //MusicSource.Play();
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                        }
                    }
                    else if(Input.GetKeyUp(KeyCode.RightArrow)) { green.SetVisible(); }

                    if (Input.GetKeyDown(KeyCode.DownArrow)) //yellow
                    {
                        yellow.SetInvisible();
                        if (patron[iterator_player] == 2)
                        {
                            //succes
                            iterator_player++;
                            //MusicSource.clip = Si;
                            //MusicSource.Play();
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                        }
                    }
                    else if(Input.GetKeyUp(KeyCode.DownArrow)) { yellow.SetVisible(); }

                    if (Input.GetKeyDown(KeyCode.LeftArrow)) //blue
                    {
                        blue.SetInvisible();
                        if (patron[iterator_player] == 0)
                        {
                            //succes
                            iterator_player++;
                            //MusicSource.clip = Do;
                            //MusicSource.Play();
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                        }
                    }
                    else if(Input.GetKeyUp(KeyCode.LeftArrow)) { blue.SetVisible(); }
                }
                if (iterator_player >= patron.Count)
                {
                    if (perfect_wait)
                    {
                        perfect_wait = false;
                        perfect_timer = Time.realtimeSinceStartup;
                        perfect_text.SetActive(true);
                    }
                    else
                    {
                        if (Time.realtimeSinceStartup - perfect_timer >= 1.0f)
                        {
                            perfect_text.SetActive(false);
                            red.SetVisible();
                            yellow.SetVisible();
                            blue.SetVisible();
                            green.SetVisible();
                            iterator = 0;
                            iterator_player = 0;
                            stage = Stage.ITERATION;
                            level++;
                            patron.Add(Random.Range(0, 4));
                        }
                    }
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