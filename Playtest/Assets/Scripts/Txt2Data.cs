using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Txt2Data : MonoBehaviour {


    void CreateText()
    {
        //PAth of the file
        string path = Application.dataPath + "/ParseVars.txt";
        //Create File 
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "PlayTesting - Variables Parsing \n\n");
        }
        //Content of the file
        string login = "Login date: " + System.DateTime.Now + "\n";
        string counter_click = "Counter value: " + /*TO DO: Acceder al script Quad.cs +*/ "\n";
        //Add some to text to it
        File.AppendAllText(path, login);
        File.AppendAllText(path, counter_click);
    }
	// Use this for initialization
	void Start () {
        CreateText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
