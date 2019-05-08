using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycloudAttackWithVelocity : CycloudAttack
{
    [SerializeField] CDBase AttackInterval = new CDBase(0.3f);


    public override void PlayerInit()
    {
        base.PlayerInit();
        AttackInterval.OnTimeOut += OnAttackEnable;
        collider.enabled = false;
        AttackInterval.Start();
    }




    public virtual void OnAttackEnable()
    {
        StartCoroutine(Attack());
        AttackInterval.Start();
    }

    IEnumerator Attack()
    {
        collider.enabled = true;
        yield return 0;
        yield return 0;
        collider.enabled = false;
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
    }
}
