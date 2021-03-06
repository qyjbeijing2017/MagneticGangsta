﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ItemBoom : PlayerFunctionBase
{
    public override string Name { get { return "ItemBoom"; } }
    public event UnityAction OnCreatItem;

    [SerializeField] private Animator m_animator;
    [SerializeField] private Collider2D m_collider;
    private SpriteRenderer m_spriteRenderer;
    private TrailRenderer m_trailRenderer;

    [Space(20)]
    [SerializeField] float m_shakeTime = 0.5f;
    [SerializeField] Vector3 m_shakeVec = new Vector3(1, 1, 0);

    [SerializeField] SpriteRenderer renderer;

    // Start is called before the first frame update
    public override void PlayerInit()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();
        }
        if (m_collider == null)
        {
            m_collider = GetComponent<Collider2D>();
        }
        m_collider.isTrigger = true;
        m_collider.enabled = false;
        GetComponent<MeteoriteFall>().OnBoom += OnBoom;
        m_animator.speed = 0;

        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_trailRenderer = GetComponent<TrailRenderer>();
    }

    void OnBoom()
    {
        m_animator.speed = 1;
        renderer.enabled = false;
        transform.up = Vector3.down;

    }

    public void BoomStart()
    {
        m_collider.enabled = true;
    }

    public void CreatItem()
    {
        OnCreatItem?.Invoke();
        print("creatItem");
    }

    public void BoomEnd()
    {
        m_collider.enabled = false;
    }

    public void BoomDestory()
    {
        Destroy(gameObject);
    }

    public void BoomShakeCamera()
    {
        Camera.main.DOShakePosition(m_shakeTime, m_shakeVec);
    }

}
