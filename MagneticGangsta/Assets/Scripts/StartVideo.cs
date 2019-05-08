using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartVideo : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.Video.VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += LoadSceneStart;
    }

    void LoadSceneStart(UnityEngine.Video.VideoPlayer vp)
    {
        DaemonTools.LoadSceneManager.Instance.LoadSceneAsync("StartScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
