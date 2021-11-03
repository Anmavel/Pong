using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    [SerializeField] private Text t_Score_Player1, t_Score_Player2, t_GameMode, t_TimeOrScore, text_Winner; // vom gleichen Typ
    private int score_Player1, score_Player2;
    private int modeInt;
    private float time, score;
    private bool gameEnd;
    

    public void Start()
    {
        modeInt = PlayerPrefs.GetInt("modeInt");

        switch (modeInt)
        {
            case 0:
                t_GameMode.text = "Endless Mode";
                break;
            case 1:
                t_GameMode.text = "Time Mode";
                time = PlayerPrefs.GetFloat("time_needed") * 60;

                break;
            case 2:
                t_GameMode.text = "Score Mode";
                score = PlayerPrefs.GetFloat("score_needed");
                t_TimeOrScore.text = "need  a score: " + score;
                break;
        }


    }


    public void Increase_Score(bool player1_Scored) // T Player 1 bekommt einen Punkt
    {
        if (player1_Scored)
        {
            score_Player1++;
            t_Score_Player1.text = score_Player1.ToString();
        }
        else
        {
            score_Player2++;
            t_Score_Player2.text = score_Player2.ToString();

        }
        if (modeInt == 2)
        {
            if (score_Player1 >= score || score_Player2 >= score)
            {
                Win();
            }
        }


    }

    private void Update()
    {

        if (modeInt != 1 || gameEnd == true) return;
        time -= Time.deltaTime;
        string time_String = TimeSpan.FromSeconds(time).ToString();
        time_String = time_String.Substring(3, 5);
        t_TimeOrScore.text = time_String;
        if (time <= 0)
        {
            Win();
        }


    }

    private void Win()
    {
        gameEnd = true;
        if (score_Player1 == score_Player2)
        {
            text_Winner.text = "It´s a Draw!!";
        }
        else if (score_Player1 > score_Player2)
        {
            text_Winner.text = "Player 1 is the winner";
        }
        else
        {
            text_Winner.text = "Player 2 is the winner";
        }
        text_Winner.gameObject.SetActive(true);

    }

    public bool GetGameEnd()
    {
        return gameEnd;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
