using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonTools;
using UnityEngine.UI;

public class GameEndPanel : UIBase
{

    [SerializeField] GameObject m_redFailed;
    [SerializeField] GameObject m_redWin;
    [SerializeField] GameObject m_blueFailed;
    [SerializeField] GameObject m_blueWin;
    [SerializeField] GameObject m_yellowFailed;
    [SerializeField] GameObject m_yellowWin;
    [SerializeField] GameObject m_greenFailed;
    [SerializeField] GameObject m_greenWin;

    [Space(20)]
    [SerializeField] Color m_redColor;
    [SerializeField] Color m_blueColor;
    [SerializeField] Color m_yellowColor;
    [SerializeField] Color m_greenColor;

    [Space(20)]
    [SerializeField] Button m_backButton;
    [SerializeField] Button m_nextLevelButton;

    [Space(20)]
    [SerializeField] GameEndPanelItem m_winItem;
    [SerializeField] GameEndPanelItem m_failedItem1;
    [SerializeField] GameEndPanelItem m_failedItem2;
    [SerializeField] GameEndPanelItem m_failedItem3;
    [Space(20)]
    [SerializeField] Animator animator;
    public override void close()
    {

    }

    public override void show(bool isfirstOpen, object[] value)
    {
        if (isfirstOpen)
        {
            m_backButton.onClick.AddListener(OnBackClicked);
            m_nextLevelButton.onClick.AddListener(OnNextLevelClicked);
        }
        PlayerStop();
        ChooseWinner();
    }


    private void PlayerStop()
    {
        var enumerator = LevelControl.Instance.Players.GetEnumerator();
        while (enumerator.MoveNext())
        {
            enumerator.Current.Value.IsLockOption = true;
            enumerator.Current.Value.PlayerRigidbody2D.velocity = Vector3.zero;
            enumerator.Current.Value.PlayerRigidbody2D.Sleep();
            enumerator.Current.Value.GetComponent<Animator>().speed = 0;
        }
        CameraFollow.Instance.enabled = false;
    }
    List<ScoreItem> scoreItems = new List<ScoreItem>();
    public void ChooseWinner()
    {
        Dictionary<Charactor, int> score = LevelControl.Instance.LevelScoreBoard.Scores;

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
        ScoreItem2GameEndPanelItem(scoreItems[0], m_winItem, true);
        ScoreItem2GameEndPanelItem(scoreItems[1], m_failedItem1, false);
        ScoreItem2GameEndPanelItem(scoreItems[2], m_failedItem2, false);
        ScoreItem2GameEndPanelItem(scoreItems[3], m_failedItem3, false);


    }
    public void AnimationChange()
    {
        switch (scoreItems[0].Player)
        {
            case Charactor.Red:
                animator.SetBool("red", true);
                break;
            case Charactor.Yellow:
                animator.SetBool("yellow", true);
                break;
            case Charactor.Blue:
                animator.SetBool("blue", true);
                break;
            case Charactor.Green:
                animator.SetBool("green", true);
                break;
            default:
                break;
        }
    }

    void ScoreItem2GameEndPanelItem(ScoreItem scoreItem, GameEndPanelItem gameEndPanelItem, bool IsWinner)
    {
        //Debug.Log(scoreItem.Player.ToString() + ":" + gameEndPanelItem.name);
        if (IsWinner)
        {
            switch (scoreItem.Player)
            {
                case Charactor.Red:
                    gameEndPanelItem.ItemInit(m_redWin, scoreItem.Score, m_redColor);
                    break;
                case Charactor.Yellow:
                    gameEndPanelItem.ItemInit(m_yellowWin, scoreItem.Score, m_yellowColor);
                    break;
                case Charactor.Blue:
                    gameEndPanelItem.ItemInit(m_blueWin, scoreItem.Score, m_blueColor);
                    break;
                case Charactor.Green:
                    gameEndPanelItem.ItemInit(m_greenWin, scoreItem.Score, m_greenColor);
                    break;
                default:
                    Debug.LogError("false");
                    break;
            }
        }
        else
        {
            switch (scoreItem.Player)
            {
                case Charactor.Red:
                    gameEndPanelItem.ItemInit(m_redFailed, scoreItem.Score, m_redColor);
                    break;
                case Charactor.Yellow:
                    gameEndPanelItem.ItemInit(m_yellowFailed, scoreItem.Score, m_yellowColor);
                    break;
                case Charactor.Blue:
                    gameEndPanelItem.ItemInit(m_blueFailed, scoreItem.Score, m_blueColor);
                    break;
                case Charactor.Green:
                    gameEndPanelItem.ItemInit(m_greenFailed, scoreItem.Score, m_greenColor);
                    break;
                default:
                    break;
            }
        }


    }


    struct ScoreItem
    {
        public Charactor Player;
        public int Score;
    }

    public void OnNextLevelClicked()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Level1Scene");
    }

    public void OnBackClicked()
    {
        LoadSceneManager.Instance.LoadSceneAsync("StartScene");
    }
}

