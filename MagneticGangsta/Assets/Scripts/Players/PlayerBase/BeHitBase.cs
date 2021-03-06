﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitBase : PlayerFunctionBase
{

    public override string Name { get { return "BeHit"; } }

    public bool IsInvincible = false;

    public void OnBeHitBefore(DamageBase damage)
    {
        OnBeHit(damage);
        for (int i = 0; i < damage.Buffes.Count; i++)
        {
            Player.BuffManager.AddBuff(damage.Buffes[i]);
        }

    }

    protected virtual void OnBeHit(DamageBase damage)
    {
        if (IsInvincible)
        {
            return;
        }

        if (Player.IsDefence)
        {
            SendMessage("OnAttackBeDefence");
            return;
        }

        if (damage.AttackPolarity != Polarity.None)
        {

            Vector2 myPoistion2Target = (damage.AttackPosition - new Vector2(Player.transform.position.x, Player.transform.position.y)).normalized;

            BeHitWihVOrF(damage, myPoistion2Target);

            if (Player.OnBeHit != null)
            {
                Player.OnBeHit(damage);
            }
        }
    }



    protected virtual void BeHitWihVOrF(DamageBase damage, Vector2 myPoistion2Target)
    {

        if (damage.AttackPolarity != Player.PlayerPolarity)
        {
            PlayerRigidbody2D.AddForce(myPoistion2Target * damage.AttackForce);
        }
        else
        {
            PlayerRigidbody2D.AddForce(-myPoistion2Target * damage.AttackForce);
        }
    }

}
