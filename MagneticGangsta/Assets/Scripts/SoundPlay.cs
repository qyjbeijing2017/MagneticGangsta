using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public void SoundStart(string eventName)
    {
        AudioController.Instance.GetEvent(eventName).start();
    }

    public void SoundStop(string eventName)
    {
        AudioController.Instance.GetEvent(eventName).stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
