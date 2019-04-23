using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonTools;
using UnityEngine.Events;
/// <summary>
/// 用于计分，该脚本应在LevelControl后执行
/// </summary>
public class ScoreBoard
{
    public Dictionary<Charactor, int> Scores = new Dictionary<Charactor, int>();

    public int KillPoint = 30;

    public event UnityAction<PlayerBase> GetScores;

    public void Init()
    {
        if (LevelControl.Instance.playerReborn)
        {
            LevelControl.Instance.playerReborn.OnDie += OnPlayerDie;
        }
        var enumerator = LevelControl.Instance.Players.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Scores.Add(enumerator.Current.Key, 0);
        }

    }

    void OnPlayerDie(PlayerBase player)
    {

        if (player.FunctionBases.ContainsKey("HitAttacker"))
        {
            HitAttacker hitAttacker = player.FunctionBases["HitAttacker"] as HitAttacker;
            if (hitAttacker.Attacker)
            {
                PlayerBase attacker = hitAttacker.Attacker;


                if (Scores.ContainsKey(attacker.charactor))
                {
                    Scores[attacker.charactor] += KillPoint;
                }
                else
                {
                    if (attacker.IsPlayer)
                        Scores.Add(attacker.charactor, KillPoint);
                }
                GetScores?.Invoke(attacker);

            }
        }
    }
}
