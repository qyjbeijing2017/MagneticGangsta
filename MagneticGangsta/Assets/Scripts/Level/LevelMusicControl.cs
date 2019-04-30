using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LevelMusicControl : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string EventPath;
    FMOD.Studio.EventInstance eventInstance;
    // Start is called before the first frame update
    void Start()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(EventPath);
        eventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
