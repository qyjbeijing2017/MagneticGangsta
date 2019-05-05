using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitWithVelocity : BeHitWithAddPower
{

    protected override void OnBeHit(DamageBase damage)
    {
        damage.AttackForce = damage.AttackSpeed;
        base.OnBeHit(damage);
    }


    protected override void BeHitWihVOrF(DamageBase damage, Vector2 myPoistion2Target)
    {
        damage.AttackSpeed = damage.AttackForce;
        if (damage.AttackPolarity != Player.PlayerPolarity)
        {
            PlayerRigidbody2D.velocity += myPoistion2Target * damage.AttackSpeed;
        }
        else
        {
            PlayerRigidbody2D.velocity -= myPoistion2Target * damage.AttackSpeed;
        }
    }
}
