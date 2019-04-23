﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CDBase : System.Object
{
    float m_cd = 1.0f;
    public float CD { get { return m_cd; } }

    public float CDTime = 0.0f;

    public event UnityAction OnTimeOut;
    public event UnityAction OnStart;

    float m_timer = 0.0f;
    float NowTimer
    {
        get
        {
            return m_timer;
        }
    }

    public CDBase()
    {
        CDTime = 0.0f;
        SceneManager.sceneUnloaded += OnSceneUnload; 
    }
    public CDBase(float time)
    {
        CDTime = time;
        SceneManager.sceneUnloaded += OnSceneUnload;
    }

    public void Start()
    {
        Stop();
        m_timer = 0.0f;
        m_cd = 0.0f;
        Daemon.Instance.DaemonUpdate += CDNow;
        OnStart?.Invoke();
    }

    void CDNow()
    {
        if (m_timer < CDTime)
        {
            m_cd = m_timer / CDTime;
            m_timer += UnityEngine.Time.deltaTime;
        }
        else
        {
            m_cd = 1.0f;        
            Stop();
            if (OnTimeOut != null) OnTimeOut.Invoke();
        }

    }
    public void Stop()
    {
        m_timer = CDTime;
        m_cd = 1.0f;
        Daemon.Instance.DaemonUpdate -= CDNow;
    }


    public void OnSceneUnload(Scene scene)
    {
        Stop();
    }
}
