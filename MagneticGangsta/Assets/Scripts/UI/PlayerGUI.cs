using System.Collections;
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

    [SerializeField] GameObject redFire;
    [SerializeField] GameObject redFireBG;
    [SerializeField] GameObject yellowFire;
    [SerializeField] GameObject yellowFireBG;
    [SerializeField] GameObject greenFire;
    [SerializeField] GameObject greenFireBG;
    [SerializeField] GameObject blueFire;
    [SerializeField] GameObject blueFireBG;


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


    Charactor getFirstPlayer()
    {
        Dictionary<Charactor, int> score = LevelControl.Instance.LevelScoreBoard.Scores;
        List<ScoreItem> scoreItems = new List<ScoreItem>();

        var enumerator = score.GetEnumerator();
        while (enumerator.MoveNext())
        {
            ScoreItem scoreItem = new ScoreItem();
            scoreItem.Player = enumerator.Current.Key;
            scoreItem.Score = enumerator.Current.Value;
            scoreItems.Add(scoreItem);
        }
        scoreItems.Sort((ScoreItem a, ScoreItem b) =>
        {
            if (a.Score > b.Score)
            {
                return -1;
            }
            else if (a.Score == b.Score)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        });
        if (scoreItems[0].Score == scoreItems[1].Score)
        {
            return Charactor.None;
        }
        else
        {
            return scoreItems[0].Player;
        }
    }



    struct ScoreItem
    {
        public Charactor Player;
        public int Score;
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

        switch (getFirstPlayer())
        {
            case Charactor.None:
                redFire.SetActive(false);
                redFireBG.SetActive(false);
                yellowFire.SetActive(false);
                yellowFireBG.SetActive(false);
                greenFire.SetActive(false);
                greenFireBG.SetActive(false);
                blueFire.SetActive(false);
                blueFireBG.SetActive(false);

                break;
            case Charactor.Red:
                redFire.SetActive(true);
                redFireBG.SetActive(true);
                yellowFire.SetActive(false);
                yellowFireBG.SetActive(false);
                greenFire.SetActive(false);
                greenFireBG.SetActive(false);
                blueFire.SetActive(false);
                blueFireBG.SetActive(false);

                break;
            case Charactor.Yellow:
                redFire.SetActive(false);
                redFireBG.SetActive(false);
                yellowFire.SetActive(true);
                yellowFireBG.SetActive(true);
                greenFire.SetActive(false);
                greenFireBG.SetActive(false);
                blueFire.SetActive(false);
                blueFireBG.SetActive(false);

                break;
            case Charactor.Blue:
                redFire.SetActive(false);
                redFireBG.SetActive(false);
                yellowFire.SetActive(false);
                yellowFireBG.SetActive(false);
                greenFire.SetActive(false);
                greenFireBG.SetActive(false);
                blueFire.SetActive(true);
                blueFireBG.SetActive(true);

                break;
            case Charactor.Green:
                redFire.SetActive(false);
                redFireBG.SetActive(false);
                yellowFire.SetActive(false);
                yellowFireBG.SetActive(false);
                greenFire.SetActive(true);
                greenFireBG.SetActive(true);
                blueFire.SetActive(false);
                blueFireBG.SetActive(false);


                break;
            default:
                break;
        }




    }



}


