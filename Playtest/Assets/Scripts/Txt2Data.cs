using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Txt2Data : MonoBehaviour {

    string login;
    string logout;
    string score;
    string high_score;
    string total_time_playing;
    string time_playing_game;
    string time_waiting;
    string number_games;
    string life_losed;

    // Use this for initialization
    void Start () {

        CreateText();
	}
	
	// Update is called once per frame
	void Update () {
        //PAth of the file
        QuadManager quad_manager = GetComponent<QuadManager>();
	}

    private void OnApplicationQuit()
    {
        string path = Application.dataPath + "/ParseVars.txt";
        total_time_playing = "Total time playing:  " + Time.realtimeSinceStartup.ToString("F2") + "\n";
        logout = "----Logout date:  " + System.DateTime.Now + "----\n";
        File.AppendAllText(path, total_time_playing);
        File.AppendAllText(path, logout);
    }

    void CreateText()
    {
        string path = Application.dataPath + "/ParseVars.txt";
        //Create File 
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "PlayTesting - Variables Parsing \n\n");
        }

        //Content of the file
        login = "----Login date:  " + System.DateTime.Now + "----\n";

        //Add some to text to it
        File.AppendAllText(path, login);
    }
}
