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
    public struct Level
    {
        public int level;
        public float start_time;
        public float total_time;
        public int lifes_lose;
    }

    public struct Round
    {
        public List<Level> level;
        public float start_time;
        public float total_time;
        public int score;
        public int life;
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
    public List<Round> round;
    
    public int times_played = 0;
    int iterator = 0;
    int iterator_player = 0;
    Stage stage = Stage.NONE;
    bool blinking = false;

    public Text counterText;
    public Text highscoreText;
    public Text levelText;
    Round ronda;
    Level round_level;
    public int highscore = 0;
    public float interval_blink = 0.5F;

    public VideoPlayer video;
    public AudioSource VideoSource;


    // Use this for initialization
    void Start () {

        SetText();

        ronda.score = 0;
        round_level.level = 1;
        ronda.life = 3;

        press_space_text.SetActive(true);
        go_text.SetActive(false);
        perfect_text.SetActive(false);
        levelText.enabled = false;

        iterator = 0;
        iterator_player = 0;
        stage = Stage.NONE;
        go_wait = false;
        patron = new List<int>();
        round = new List<Round>();
        ronda.level = new List<Level>();
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

                    ronda.start_time = Time.realtimeSinceStartup;

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

                    round_level.start_time = Time.realtimeSinceStartup;
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
                            ronda.score++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            ronda.life--;
                            round_level.lifes_lose++;
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
                            ronda.score++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            ronda.life--;
                            round_level.lifes_lose++;
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
                            ronda.score++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            ronda.life--;
                            round_level.lifes_lose++;
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
                            ronda.score++;
                        }
                        else
                        {
                            //fail
                            MusicSource.clip = GameOver_fx;
                            MusicSource.Play();
                            ronda.life--;
                            round_level.lifes_lose++;
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
                            round_level.total_time = Time.realtimeSinceStartup - round_level.start_time;
                            ronda.level.Add(round_level);

                            round_level.level++;
                            round_level.start_time = Time.realtimeSinceStartup;
                            round_level.lifes_lose = 0;

                            if(ronda.level.Count >= 5 && red.idle_time >= 0.05f)
                            {
                                red.idle_time -= 0.05f;
                                blue.idle_time -= 0.05f;
                                green.idle_time -= 0.05f;
                                yellow.idle_time -= 0.05f;
                            }

                            patron.Add(Random.Range(0, 4));
                        }
                    }
                }
                SetText();

                break;
            case Stage.RESTART:
                stage = Stage.NONE;

                ronda.total_time = Time.realtimeSinceStartup - ronda.start_time;

                round.Add(ronda);

                ronda.score = 0;
                ronda.life = 3;

                round_level.level = 1;
                round_level.lifes_lose = 0;

                press_space_text.SetActive(true);
                go_text.SetActive(false);
                perfect_text.SetActive(false);
                levelText.enabled = false;
                
                go_wait = false;

                patron.Clear();
                patron = new List<int>();
                patron.Add(Random.Range(0, 4));

                MusicSource.clip = Start_fx;
                MusicSource.Play();

                iterator = 0;
                iterator_player = 0;


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
        switch (ronda.life)
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
        counterText.text = "Score: " + ronda.score.ToString();
        levelText.text = "Level: " + round_level.level.ToString();
        if (highscore <= ronda.score)
        {
            highscore = ronda.score;
            highscoreText.text = "High score: " + ronda.score.ToString();
        }
    }


}