using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonTools;
using UnityEngine.Events;
public class LevelControl : MonoSingleton<LevelControl>
{
    private Dictionary<Charactor, PlayerBase> m_players = null;

    public Dictionary<Charactor, PlayerBase> Players
    {
        get
        {
            if (m_players != null)
            {
                
                return m_players;
            }
            else
            {
                Debug.Log("find");
                return FindPlayers();
            }
        }
    }
    public PlayerReborn playerReborn;
    public ScoreBoard LevelScoreBoard = new ScoreBoard();

    public CDBase LevelTime = new CDBase(120.0f);

    new void Awake()
    {
        base.Awake();


        if (!playerReborn)
        {
            playerReborn = FindObjectOfType<PlayerReborn>();
        }
        FindPlayers();

        Daemon.Instance.Init();

    }

    // Start is called before the first frame update
    void Start()
    {
        LevelTime.OnTimeOut += OnLevelEnd;
        LevelTime.OnTimeOut += onGameEnd;
        LevelTime.Start();
        LevelScoreBoard.Init();

        UIManager.Instance.Open("GUIPanel");
    }

    void OnLevelEnd()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public Dictionary<Charactor, PlayerBase> FindPlayers()
    {

        m_players = new Dictionary<Charactor, PlayerBase>();
        PlayerBase[] players = FindObjectsOfType<PlayerBase>();
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].IsPlayer)
                m_players.Add(players[i].charactor, players[i]);
        }
        return m_players;
    }


    void onGameEnd()
    {
        UIManager.Instance.Open("GameEndPanel");
    }
}
