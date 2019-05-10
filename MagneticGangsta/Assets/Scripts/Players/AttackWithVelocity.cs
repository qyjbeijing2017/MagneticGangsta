using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithVelocity : AttackWithCost
{
    public override void PlayerInit()
    {
        if (!collider)
            collider = GetComponent<CircleCollider2D>() as Collider2D;

        collider.enabled = false;      

        AttackDamage.Attacker = this;
    }


    protected override void AttackNow()
    {
        if (Player.FunctionBases.ContainsKey("Power"))
        {
            Power power = Player.FunctionBases["Power"] as Power;
            if (!power.PowerCost(AttackCost)) return;
        }
        attack = true;
        AttackTime.Start();
        AttackCD.Start();
    }

    bool attack = false;
    private void FixedUpdate()
    {
        collider.enabled = false;
        if (attack)
        {
            collider.enabled = true;
            attack = false;
        }
        
    }


    public override void PlayerLoop()
    {
        base.PlayerLoop();
    }

    protected override void ReactionForce(PlayerBase enemy)
    {
        if (AttackDamage.AttackPolarity == Polarity.None)
        {
            return;
        }

        Vector2 myPoistion2Target = (new Vector2(enemy.transform.position.x, enemy.transform.position.y) - AttackDamage.AttackPosition).normalized;

        if (AttackDamage.AttackPolarity != enemy.PlayerPolarity)
        {
            PlayerRigidbody2D.velocity += myPoistion2Target * AttackDamage.AttackSpeed * ReactionCoefficient;
        }
        else
        {
            PlayerRigidbody2D.velocity -= myPoistion2Target * AttackDamage.AttackSpeed * ReactionCoefficient;
        }


    }


    protected override void OnTriggerStay2D(Collider2D collision)
    {
        //base.OnTriggerStay2D(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}
