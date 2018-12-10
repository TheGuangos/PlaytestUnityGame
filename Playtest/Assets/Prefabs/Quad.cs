using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    public enum State
    {
        NOFADE,
        FADETOINV,
        IDLE,
        FADETOVIS
    }

    public State state = State.NOFADE;
    public SpriteRenderer sprite;

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
                    state = State.IDLE;
                break;
            case State.IDLE:
                break;
            case State.FADETOINV:
                break;
            
        }
	}
}
