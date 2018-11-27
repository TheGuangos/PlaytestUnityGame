using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadManager : MonoBehaviour {

    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject green;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            red.GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            red.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }
}
