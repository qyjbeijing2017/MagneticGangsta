using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeHitWithAddPower : BeHitWithNonePolarity
{
    [Header("当前击飞值")] public float StrikeFlyValue;
    [Header("受攻击时每帧增加击飞值")] public float StrikeFlyAddValue;
    [Header("最低击飞系数")] public float MinAttackCoefficient;
    [Header("最高击飞系数")] public float MaxAttackCoefficient;

    protected override void OnBeHit(DamageBase damage)
    {
        if (IsInvincible)
        {
            return;
        }
        DamageBase damageNew = damage.Copy();
        AddStrikeFlyValue();
        damageNew.AttackForce = damage.AttackForce * Mathf.Lerp(MinAttackCoefficient, MaxAttackCoefficient, StrikeFlyValue);
        base.OnBeHit(damageNew);

    }

    protected virtual void AddStrikeFlyValue()
    {
        StrikeFlyValue += StrikeFlyAddValue;
        if (StrikeFlyValue >= 1)
        {
            StrikeFlyValue = 1;
        }
    }

    public override void OnPlayerDie()
    {
        StrikeFlyValue = 0;
        base.OnPlayerDie();
    }
}
