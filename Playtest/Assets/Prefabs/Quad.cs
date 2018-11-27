using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    enum State
    {
        NOFADE,
        FADETOINV,
        IDLE,
        FADETOVIS
    }

    State state = State.NOFADE;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.NOFADE:
                state = State.FADETOINV;
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
