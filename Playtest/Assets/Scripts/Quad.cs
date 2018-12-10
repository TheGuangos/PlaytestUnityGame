using System.Collections;
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

    float timer = 0;

    float alpha = 0.01f;
    Color color;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.NOFADE:
                //state = State.FADETOINV;
                break;
            case State.FADETOVIS:
                color.a -= alpha;
                sprite.color = color;
                if (color.a <= 0.0f)
                {
                    state = State.IDLE;
                    timer = Time.realtimeSinceStartup;
                }
                break;
            case State.IDLE:
                if (Time.realtimeSinceStartup - timer >= 1.0f)
                {
                    state = State.FADETOINV;
                }
                break;
            case State.FADETOINV:
                color.a += alpha;
                sprite.color = color;
                if (color.a >= 1.0f)
                    state = State.COMPLETED;
                break;
            case State.COMPLETED:
                state = State.NOFADE;
                break;
            
        }
	}
}
