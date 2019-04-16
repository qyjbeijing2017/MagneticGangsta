﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformEffector2D))]
public class HitPlatformEffect : PlayerFunctionBase
{
    public override string Name { get { return "HitPlatformEffect"; } }


    public CDBase BeHitEffectTime = new CDBase(0.3f);
    public float HitAngle = 60.0f;

    [SerializeField] protected PlatformEffector2D m_platformEffector;
    public override void PlayerInit()
    {
        if (!m_platformEffector)
            m_platformEffector = GetComponent<PlatformEffector2D>();

        m_platformEffector.useOneWay = false;
        m_platformEffector.useColliderMask = false;
        Player.OnBeHit += OnBeHit;
        BeHitEffectTime.OnTimeOut += OnEffectEnd;
    }


    virtual protected void OnBeHit(DamageBase damage)
    {
        Vector2 orgin2Attacker = damage.Attacker.Player.transform.position - Player.transform.position;
        float attackAngle = Vector2.Angle(orgin2Attacker, Vector2.up) * 2.0f;
        if (attackAngle > HitAngle) return;

        BeHitEffectTime.Start();

        m_platformEffector.useOneWay = true;
        m_platformEffector.useColliderMask = true;
    }

    virtual protected void OnEffectEnd()
    {
        BeHitEffectTime.Stop();
        m_platformEffector.useOneWay = false;
        m_platformEffector.useColliderMask = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == m_platformEffector.colliderMask)
        {
            OnEffectEnd();
        }
    }




    public override void OnPlayerDie()
    {
        OnEffectEnd();
    }

}
