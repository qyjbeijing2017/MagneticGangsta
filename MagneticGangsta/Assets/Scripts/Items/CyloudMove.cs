using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CyloudMove : PlayerFunctionBase
{

    public CycloudTargetPosition TargetPosition;
    public float Speed = 3.0f;
    public Vector2 MoveAdd = new Vector3(0, 0, 0);

    private Vector2 m_nowPosition;

    public UnityAction OnDestory;

    FMOD.Studio.EventInstance cyloudEvent;

    void Start()
    {
        transform.position = TargetPosition.StartPositon;
        m_nowPosition = TargetPosition.StartPositon;
        cyloudEvent = AudioController.Instance.CreatEvent("FengBao");
        cyloudEvent.start();
    }

    // Update is called once per frame
    void Update()
    {
            
        if (TargetPosition.Start2End.magnitude <= (m_nowPosition- TargetPosition.StartPositon).magnitude )
        {
            OnDestory?.Invoke();
            cyloudEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Destroy(gameObject);

        }
        else
        {
            m_nowPosition += TargetPosition.Start2End.normalized * Speed * Time.deltaTime;
            transform.position = m_nowPosition + MoveAdd;
        }
    }
}
