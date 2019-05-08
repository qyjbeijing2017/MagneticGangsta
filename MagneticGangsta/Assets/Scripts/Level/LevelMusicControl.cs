using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LevelMusicControl : MonoBehaviour
{
    public string AudioEvnetName;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.Instance.StopAll();
        AudioController.Instance.GetEvent(AudioEvnetName).start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
