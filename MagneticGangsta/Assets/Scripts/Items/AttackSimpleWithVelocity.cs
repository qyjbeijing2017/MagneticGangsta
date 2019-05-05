using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSimpleWithVelocity :AttackSimple
{


    public override void PlayerInit()
    {
        base.PlayerInit();
        collider.enabled = false;
    }

    public virtual void OnAttackEnable()
    {
        collider.enabled = true;
    }

    public override void PlayerLoop()
    {
        collider.enabled = false;
        base.PlayerLoop();
    }


    protected override void OnAttack(Collider2D collision)
    {
        AttackDamage.AttackForce = AttackDamage.AttackSpeed;
        base.OnAttack(collision);
    }
    protected override void BeHitWihVOrF(BeHitBase beHit, DamageBase damage)
    {
        damage.AttackSpeed = damage.AttackForce;
        base.BeHitWihVOrF(beHit, damage);
    }
}
