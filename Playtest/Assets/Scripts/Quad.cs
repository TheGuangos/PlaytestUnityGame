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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.NOFADE:
                //state = State.FADETOINV;
                break;
            case State.IDLE:
                break;
            case State.FADETOINV:
                break;
            case State.FADETOVIS:
                break;
        }
	}
}
