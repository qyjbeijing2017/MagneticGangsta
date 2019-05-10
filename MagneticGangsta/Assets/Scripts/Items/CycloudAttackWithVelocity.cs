using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloudAttackWithVelocity : CycloudAttack
{
    [SerializeField] CDBase AttackInterval = new CDBase(0.3f);

    bool Attack = false;
    private void FixedUpdate()
    {
        collider.enabled = false;
        if (Attack)
        {
            collider.enabled = true;
            Attack = false;

        }
    }

    public override void PlayerInit()
    {
        base.PlayerInit();
        AttackInterval.OnTimeOut += OnAttackEnable;
        collider.enabled = false;
        AttackInterval.Start();
    }




    public virtual void OnAttackEnable()
    {
        Attack = true;
        AttackInterval.Start();
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
        beHit.Player.PlayerRigidbody2D.velocity = Vector3.zero;
        base.BeHitWihVOrF(beHit, damage);
    }
    private void OnDestroy()
    {
        AttackInterval.OnTimeOut -= OnAttackEnable;
    }
}
