using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteFallSound : MonoBehaviour
{

    FMOD.Studio.EventInstance mereoriteFallEvent;


    // Start is called before the first frame update
    void Start()
    {
        mereoriteFallEvent = AudioController.Instance.CreatEvent("YunShiZhuiLuo");
        mereoriteFallEvent.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBoomSound()
    {
        AudioController.Instance.CreatEvent("YunShiBaoZha").start();
    }

    public void OnFallDown()
    {
        mereoriteFallEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
