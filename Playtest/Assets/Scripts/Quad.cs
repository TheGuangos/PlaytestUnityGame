﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    public enum State
    {
        NOFADE,
        FADETOINV,
        IDLE,
        FADETOVIS,
        COMPLETED
    }
    [HideInInspector] public State state = State.NOFADE;
    public SpriteRenderer sprite;
    Behaviour halo;
    public float idle_time;
    public float transition_time = 0.05f;

    float timer = 0;

    Color color;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
        halo = (Behaviour)gameObject.GetComponent("Halo");
        halo.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.NOFADE:
                //state = State.FADETOINV;
                break;
            case State.FADETOVIS:
                color.a -= transition_time;
                sprite.color = color;
                if (color.a <= 0.0f)
                {
                    state = State.IDLE;
                    timer = Time.realtimeSinceStartup;
                    halo.enabled = true;
                }
                break;
            case State.IDLE:
                if (Time.realtimeSinceStartup - timer >= idle_time)
                {
                    state = State.FADETOINV;
                    halo.enabled = false;
                }
                break;
            case State.FADETOINV:
                color.a += transition_time;
                sprite.color = color;
                if (color.a >= 1.0f)
                    state = State.COMPLETED;
                break;
            case State.COMPLETED:
                state = State.NOFADE;
                break;
            
        }
	}

    public void SetInvisible()
    {
        color.a = 0.0f;
        sprite.color = color;
    }

    public void SetVisible()
    {
        color.a = 1.0f;
        sprite.color = color;
    }
}
