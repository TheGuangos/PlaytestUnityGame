using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Txt2Data : MonoBehaviour {

    string login;
    string logout;
    string score;
    string rounds;
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

        high_score = Environment.NewLine + "High Score: " + cs.highscore;
        for(int i = 0; i < cs.round.Count; ++i)
        {
            rounds += Environment.NewLine + "Num round: " + i;
            for(int j = 0; j < cs.round[i].level.Count; ++j)
            {
                rounds += Environment.NewLine + "Level: " + j;
                rounds += Environment.NewLine + "Lifes lost: " + cs.round[i].level[j].lifes_lose;
                rounds += Environment.NewLine + "Start time: " + cs.round[i].level[j].start_time;
                rounds += Environment.NewLine + "Total time: " + cs.round[i].level[j].total_time;
            }

            rounds += Environment.NewLine + "Max level: " + cs.round[i].level.Count;
            rounds += Environment.NewLine + "Score: " + cs.round[i].score;
            rounds += Environment.NewLine + "Lifes: " + cs.round[i].life;
            rounds += Environment.NewLine + "Start time: " + cs.round[i].start_time;
            rounds += Environment.NewLine + "Total time: " + cs.round[i].total_time;
        }
        
        logout = "----Logout date:  " + System.DateTime.Now + "----" + Environment.NewLine;
        File.AppendAllText(path, number_games);
        File.AppendAllText(path, high_score);
        File.AppendAllText(path, rounds);
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
