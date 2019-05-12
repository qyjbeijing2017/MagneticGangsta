﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageBase : System.Object
{
    [HideInInspector] public PlayerFunctionBase Attacker = null;
    public float AttackForce = 300.0f;
    public Polarity AttackPolarity = Polarity.None;
    public List<PlayerBuffBase> Buffes = new List<PlayerBuffBase>();
    [HideInInspector] public Vector2 AttackPosition = Vector2.zero;
    public float AttackSpeed;
    public bool BeHitEffectOn = true;
    public bool SoundPlay = true;


    public virtual DamageBase Copy()
    {
        DamageBase copy = new DamageBase();
        copy.AttackForce = AttackForce;
        copy.AttackPolarity = AttackPolarity.Copy();
        for (int i = 0; i < Buffes.Count; i++) copy.Buffes.Add(Buffes[i].Copy());
        copy.AttackPosition = AttackPosition;
        copy.Attacker = Attacker;
        copy.AttackSpeed = AttackSpeed;
        copy.BeHitEffectOn = BeHitEffectOn;
        copy.SoundPlay = SoundPlay;
        return copy;
    }
}

