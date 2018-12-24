using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuadManager : MonoBehaviour {

    enum Stage
    {
        NONE,
        ITERATION,
        PLAYER,
        RESTART
    }

    public AudioClip Do;
    public AudioClip Mi;
    public AudioClip Si;
    public AudioClip Sol;
    public AudioClip Start_fx;
    public AudioClip GameOver_fx;
    public AudioSource MusicSource;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Quad blue;
    public Quad red;
    public Quad green;
    public Quad yellow;

    public GameObject press_space_text;

    public GameObject go_text;
    bool go_wait = false;
    float go_timer = 0.0f;
    public GameObject perfect_text;
    bool perfect_wait = false;
    float perfect_timer = 0.0f;

    List<int> patron;
    public int times_played = 0;
    int iterator = 0;
    int iterator_player = 0;
    Stage stage = Stage.NONE;
    bool blinking = false;
    int level = 1;

    int rounds = 0;

    int lifes = 3;

    public Text counterText;
    public Text highscoreText;
    public Text levelText;
    public int counter_clicks = 0;
    public int highscore = 0;
    
    public float interval_blink = 0.5F;

    public VideoPlayer video;
    public AudioSource VideoSource;


    // Use this for initialization
    void Start () {

        SetText();
        counter_clicks = 0;

        press_space_text.SetActive(true);
        go_text.SetActive(false);
        perfect_text.SetActive(false);
        levelText.enabled = false;

        lifes = 3;

        iterator = 0;
        iterator_player = 0;
        stage = Stage.NONE;
        go_wait = false;
        patron = new List<int>();
        patron.Add(Random.Range(0, 4));

        MusicSource.clip = Start_fx;
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
                    go_text.SetActive(false);
                    blinking = false;
                    press_space_text.SetActive(false);
                    levelText.enabled = true;
                    times_played++;

                    rounds++;

                    if (times_played == 3 || times_played == 5)
                    {
                        video.Play();
                    }
                    if (times_played == 2 || times_played == 5)
                    {

                    }
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
                    stage = Stage.PLAYER;
                    go_text.SetActive(true);
                    go_wait = true;
                    go_timer = Time.realtimeSinceStartup;
                }
                break;
            case Stage.PLAYER:

                if (go_wait && Time.realtimeSinceStartup - go_timer >= 0.25f)
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
                            MusicSource.clip = Mi;
                            MusicSource.Play();
                            counter_clicks++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            lifes--;
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.UpArrow)) { red.SetVisible(); }

                    if (Input.GetKeyDown(KeyCode.RightArrow)) //green
                    {
                        green.SetInvisible();
                        if (patron[iterator_player] == 3)
                        {
                            //succes
                            iterator_player++;
                            MusicSource.clip = Sol;
                            MusicSource.Play();
                            counter_clicks++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            lifes--;
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.RightArrow)) { green.SetVisible(); }

                    if (Input.GetKeyDown(KeyCode.DownArrow)) //yellow
                    {
                        yellow.SetInvisible();
                        if (patron[iterator_player] == 2)
                        {
                            //succes
                            iterator_player++;
                            MusicSource.clip = Si;
                            MusicSource.Play();
                            counter_clicks++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            lifes--;
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.DownArrow)) { yellow.SetVisible(); }

                    if (Input.GetKeyDown(KeyCode.LeftArrow)) //blue
                    {
                        blue.SetInvisible();
                        if (patron[iterator_player] == 0)
                        {
                            //succes
                            iterator_player++;
                            MusicSource.clip = Do;
                            MusicSource.Play();
                            counter_clicks++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            lifes--;
                        }
                    }
                    else if (Input.GetKeyUp(KeyCode.LeftArrow)) { blue.SetVisible(); }
                    SetLife();
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
                            if(level>=5 && red.idle_time >= 0.05f)
                            {
                                red.idle_time -= 0.05f;
                                blue.idle_time -= 0.05f;
                                green.idle_time -= 0.05f;
                                yellow.idle_time -= 0.05f;
                                print(red.idle_time);
                            }

                            patron.Add(Random.Range(0, 4));
                        }
                    }
                }
                SetText();

                break;
            case Stage.RESTART:
                stage = Stage.NONE;
                
                counter_clicks = 0;

                press_space_text.SetActive(true);
                go_text.SetActive(false);
                perfect_text.SetActive(false);
                levelText.enabled = false;

                lifes = 3;
                
                go_wait = false;

                patron.Clear();
                patron = new List<int>();
                patron.Add(Random.Range(0, 4));

                MusicSource.clip = Start_fx;
                MusicSource.Play();

                iterator = 0;
                iterator_player = 0;
                level = 0;

                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);

                SetText();
                video.Stop();
                blue.SetVisible();
                yellow.SetVisible();
                red.SetVisible();
                green.SetVisible();

                break;
            default:
                break;
        }
    }

    private void SetLife()
    {
        switch (lifes)
        {
            case 3:
                break;
            case 2:
                heart1.SetActive(false);
                break;
            case 1:
                heart1.SetActive(false);
                heart2.SetActive(false);
                break;
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                stage = Stage.RESTART;
                break;
            default:
                break;
        }
    }

    void SetText()
    {
        counterText.text = "Score: " + counter_clicks.ToString();
        levelText.text = "Level: " + level.ToString();
        if (highscore <= counter_clicks)
        {
            highscore = counter_clicks;
            highscoreText.text = "High score: " + counter_clicks.ToString();
        }
    }


}