﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : UIBase
{

    [SerializeField] Text m_red;
    [SerializeField] Text m_blue;
    [SerializeField] Text m_yellow;
    [SerializeField] Text m_green;


    ScoreBoard scoreBoard;


    public override void close()
    {

    }

    public override void show(bool isfirstOpen, object[] value)
    {
        if (isfirstOpen)
        {
            m_red.text = "0";
            m_blue.text = "0";
            m_yellow.text = "0";
            m_green.text = "0";
            scoreBoard = LevelControl.Instance.LevelScoreBoard;
            scoreBoard.GetScores += ShowScore;
        }
        ShowScore(null);
    }


    private void ShowScore(PlayerBase player)
    {
        if (scoreBoard.Scores.ContainsKey(Charactor.Red))
        {
            m_red.text = scoreBoard.Scores[Charactor.Red].ToString();
        }
        if (scoreBoard.Scores.ContainsKey(Charactor.Yellow))
        {
            m_yellow.text = scoreBoard.Scores[Charactor.Yellow].ToString();
        }
        if (scoreBoard.Scores.ContainsKey(Charactor.Blue))
        {
            m_blue.text = scoreBoard.Scores[Charactor.Blue].ToString();
        }
        if (scoreBoard.Scores.ContainsKey(Charactor.Green))
        {
            m_green.text = scoreBoard.Scores[Charactor.Green].ToString();
        }
    }
}


