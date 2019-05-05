using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitWithCoefficient : BeHitBase
{

    public float AttackForceCoefficient = 1.0f;

    protected override void OnBeHit(DamageBase damage)
    {
        damage.AttackForce *= AttackForceCoefficient;
        base.OnBeHit(damage);
    }


}
