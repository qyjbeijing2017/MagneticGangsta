﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBase : MonoBehaviour
{

    public int ID;
    public Charactor charactor;

    virtual public bool IsPlayer { get { return true; } }



    #region Attribute

    public bool IsMoving = false;
    public bool IsOnGround = false;
    public bool IsLockOption = false;
    public bool IsDefence = false;
    public bool IsDead = false;

    public Rigidbody2D PlayerRigidbody2D;

    public Polarity PlayerPolarity = Polarity.North;
    public CapsuleCollider2D MainCollider;
    #endregion

    #region Events

    public UnityAction<DamageBase> OnBeHit;
    public UnityAction<PlayerBase> OnAttack;
    public UnityAction<int> OnJump;
    public UnityAction OnChangePolarity;

    public UnityAction OnGroundBefroe;
    public UnityAction OnGround;
    public UnityAction OnExitGround;

    public UnityAction OnDie;
    public UnityAction OnReborn;
    #endregion Events

    Dictionary<string, PlayerFunctionBase> m_functionBases = new Dictionary<string, PlayerFunctionBase>();


    public Dictionary<string, PlayerFunctionBase> FunctionBases { get { return m_functionBases; } }

    PlayerBuffManager m_buffManager;
    public PlayerBuffManager BuffManager { get { return m_buffManager; } }
    void PlayerFuncsLoop()
    {

        var funcEnumerator = m_functionBases.GetEnumerator();
        while (funcEnumerator.MoveNext())
        {
            if (!funcEnumerator.Current.Value.FunctionEnable) continue;
            funcEnumerator.Current.Value.PlayerLoop();
        }

    }

    void InitPlayerFuncs()
    {
        PlayerFunctionBase[] playerFunctionBases = GetComponents<PlayerFunctionBase>();
        for (int i = 0; i < playerFunctionBases.Length; i++)
        {
            playerFunctionBases[i].Player = this;
            OnDie += playerFunctionBases[i].OnPlayerDie;
            if (!m_functionBases.ContainsKey(playerFunctionBases[i].Name)) m_functionBases.Add(playerFunctionBases[i].Name, playerFunctionBases[i]);
        }

        var enumerator = FunctionBases.GetEnumerator();
        while (enumerator.MoveNext())
        {
            enumerator.Current.Value.PlayerInit();

        }

    }

    void InitBuffManager()
    {
        PlayerBuffManager playerBuffManager = GetComponent<PlayerBuffManager>();
        if (playerBuffManager)
        {
            playerBuffManager.Init(this);
            m_buffManager = playerBuffManager;
        }
    }

    private void Awake()
    {

        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        MainCollider = !MainCollider ? GetComponent<CapsuleCollider2D>() : MainCollider;
        OnDie += OnPlayerDie;
        InitPlayerFuncs();
        InitBuffManager();
    }
    private void Update()
    {
        if (!IsLockOption)
        {
            PlayerFuncsLoop();
        }
    }

    private void InitPlayer()
    {
        IsMoving = false;
        IsOnGround = false;
        IsLockOption = false;

    }


    private void OnPlayerDie()
    {
        IsMoving = false;
        IsOnGround = false;
        IsLockOption = true;
        IsDefence = false;
        IsDead = true;
        gameObject.SetActive(false);
    }


    public void ReBorn(Vector2 position)
    {
        transform.position = position;
        IsLockOption = false;
        gameObject.SetActive(true);
        IsDead = false;
    }

}

