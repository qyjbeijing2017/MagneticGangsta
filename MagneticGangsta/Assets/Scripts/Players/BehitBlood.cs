using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehitBlood : MonoBehaviour
{
    [SerializeField] PlayerBase m_player;
    [SerializeField] GameObject m_effect;
    [SerializeField] Animator m_animator;

    public void Start()
    {
        m_effect.SetActive(false);
        m_player.OnBeHit += OnBeHit;
    }



    void OnBeHit(DamageBase damageBase)
    {
        Vector2 attackdir = new Vector3(damageBase.AttackPosition.x, damageBase.AttackPosition.y, transform.position.z) - transform.position;
        m_effect.SetActive(true);
        m_effect.transform.right = attackdir;
    }

    public void EffectEnd()
    {
        m_effect.SetActive(false);
    }

}
