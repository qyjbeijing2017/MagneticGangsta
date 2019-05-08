using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonTools;
using FMODUnity;

public class AudioController : MonoSingleton<AudioController>
{
    [SerializeField]List<AudioPath> Paths;

    Dictionary<string, FMOD.Studio.EventInstance> AudioEvents = new Dictionary<string, FMOD.Studio.EventInstance>();


    new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {

        for (int i = 0; i < Paths.Count; i++)
        {
            FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance(Paths[i].EventPath);
            AudioEvents.Add(Paths[i].EventName, eventInstance);
        }
    }
    public  FMOD.Studio.EventInstance GetEvent(string name)
    {
        return AudioEvents[name];
    }
    public void StopAll()
    {
        var enumerator = AudioEvents.GetEnumerator();
        while (enumerator.MoveNext())
        {
            enumerator.Current.Value.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

    }
}
[System.Serializable]
public class AudioPath : System.Object
{
    public string EventName;
    [FMODUnity.EventRef]
    public string EventPath;
}