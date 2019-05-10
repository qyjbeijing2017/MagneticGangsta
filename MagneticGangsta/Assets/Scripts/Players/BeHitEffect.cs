using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitEffect : PlayerFunctionBase
{
    public override string Name { get { return "BeHitEffect"; } }
    public float DelayTime = 0.3f;
    public float DelayLength = 0.05f;

    public override void PlayerInit()
    {
        Player.OnBeHit += OnDelayBeHit;
        Player.OnAttack += OnDelayAttack;
    }

    void OnDelayBeHit(DamageBase damage)
    {
        if (!damage.BeHitEffectOn) return;
        Vector2 target2MyPos =  (Vector2)transform.position - damage.AttackPosition;

        if(damage.AttackPolarity == Polarity.None)
        {
            transform.position += (Vector3)target2MyPos.normalized * DelayLength;
        }
        else if (damage.AttackPolarity != Player.PlayerPolarity )
        {
            transform.position -= (Vector3)target2MyPos.normalized * DelayLength;
        }
        else
        {
            transform.position += (Vector3)target2MyPos.normalized * DelayLength;
        }

        Delay delay = new Delay(DelayTime);
        Player.BuffManager.AddBuff(delay);

    }
    void OnDelayAttack(PlayerBase player)
    {

        Delay delay = new Delay(DelayTime);
        Player.BuffManager.AddBuff(delay);

    }

}
