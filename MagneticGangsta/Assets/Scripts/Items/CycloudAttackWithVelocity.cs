using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloudAttackWithVelocity : CycloudAttack
{
    CDBase AttackInterval = new CDBase(0.3f);

    public override void PlayerInit()
    {
        base.PlayerInit();
        AttackInterval.OnTimeOut += OnAttackEnable;
        collider.enabled = false;
        AttackInterval.Start();
    }

    public virtual void OnAttackEnable()
    {
        collider.enabled = true;
        AttackInterval.Start();
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
