using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSimpleWithVelocity :AttackSimple
{
    public bool Attack = false;


    private void FixedUpdate()
    {
        collider.enabled = false;
        if(Attack)
        {
            collider.enabled = true;
            Attack = false;
        }
    }

    public override void PlayerInit()
    {
        base.PlayerInit();
        collider.enabled = false;
    }

    public virtual void OnAttackEnable()
    {
        Attack = true;
    }

    public override void PlayerLoop()
    {
        
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
