using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RebornEffect : MonoBehaviour
{
    UnityAction<PlayerBase> m_onShow;
    UnityAction<PlayerBase> m_onEnd;
    PlayerBase m_player;
    Animator animator;


    public void RebornStart(PlayerBase player,UnityAction<PlayerBase> onShow, UnityAction<PlayerBase> onEnd)
    {
        m_onEnd += onEnd;
        m_onShow = onShow;
        m_player = player;
        animator = GetComponent<Animator>();
        animator.speed = 1;
    }
    
    public void OnShow()
    {
        m_onShow?.Invoke(m_player);
    }

    public void OnEnd()
    {
        m_onEnd?.Invoke(m_player);
        Destroy(gameObject);
    }
}
