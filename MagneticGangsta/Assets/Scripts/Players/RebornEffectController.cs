using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebornEffectController : PlayerFunctionBase
{
    public override string Name { get { return "RebornEffectController"; } }
    [SerializeField] private RebornEffect m_rebornEffect;

    public override void PlayerInit()
    {
        Player.OnReborn += () =>
        {
            RebornEffect rebornEffect = Instantiate(m_rebornEffect,gameObject.transform.position,gameObject.transform.rotation);
            rebornEffect.RebornStart(Player, (player) =>
            {
                player.gameObject.SetActive(true);             
                player.IsDead = false;
                (player.FunctionBases["BeHit"] as BeHitBase).IsInvincible = true;
            }, (player) =>
            {
                (player.FunctionBases["BeHit"] as BeHitBase).IsInvincible = false;
                player.IsLockOption = false;
            });
        };
    }
}
