using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitWithNonePolarity : BeHitWithCoefficient
{


    protected override void OnBeHit(DamageBase damage)
    {
        if (IsInvincible)
        {
            return;
        }
        base.OnBeHit(damage);

        if (damage.AttackPolarity == Polarity.None)
        {
            Vector2 myPoistion2Target = (damage.AttackPosition - new Vector2(Player.transform.position.x, Player.transform.position.y)).normalized;
            BeHitWihVOrF(damage, myPoistion2Target);
            Player.OnBeHit?.Invoke(damage);
        }
    }

    protected override void BeHitWihVOrF(DamageBase damage, Vector2 myPoistion2Target)
    {
        base.BeHitWihVOrF(damage, myPoistion2Target);
        if (damage.AttackPolarity == Polarity.None)
        {
            PlayerRigidbody2D.AddForce(myPoistion2Target * damage.AttackForce);
        }
    }
}
