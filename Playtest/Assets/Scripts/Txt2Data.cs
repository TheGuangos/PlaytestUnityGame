using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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
	}

    private void OnApplicationQuit()
    {
        GameObject quadm = GameObject.Find("Quads");
        QuadManager cs = quadm.GetComponent<QuadManager>();

        string path = Application.dataPath + "/ParseVars.txt";
        number_games = "Number of Games:    " + cs.times_played + Environment.NewLine;
        high_score = "High Score:   " + cs.highscore + Environment.NewLine;
        total_time_playing = "Total time playing:   " + Time.realtimeSinceStartup.ToString("F2") + Environment.NewLine;
        logout = "----Logout date:  " + System.DateTime.Now + "----" + Environment.NewLine;
        File.AppendAllText(path, number_games);
        File.AppendAllText(path, high_score);
        File.AppendAllText(path, total_time_playing);
        File.AppendAllText(path, logout);
    }

    void CreateText()
    {
        string path = Application.dataPath + "/ParseVars.txt";
        //Create File 
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "PlayTesting - Variables Parsing" + Environment.NewLine + "Player:  <Set number>" + Environment.NewLine + "Name:	<Set name>" + Environment.NewLine + "Age:	<Set age>" + Environment.NewLine + "Gender:	<Set Gender>" + Environment.NewLine + "Experience:	< Low / Medium / High >" + Environment.NewLine);
        }

        //Content of the file
        login = Environment.NewLine + "----Login date:  " + System.DateTime.Now + "----" + Environment.NewLine;

        //Add some to text to it
        File.AppendAllText(path, login);
    }
}
