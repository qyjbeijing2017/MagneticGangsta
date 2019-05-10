using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DaemonTools;

public class ChooseLevelSceneEffect : MonoBehaviour
{
    [SerializeField] Button Level1;
    [SerializeField] Button Level2;
    [SerializeField] Button Level3;

    // Start is called before the first frame update
    void Start()
    {
        Level1.onClick.AddListener(OnChooseLevel1);
        Level2.onClick.AddListener(OnChooseLevel2);
        Level3.onClick.AddListener(OnChooseLevel3);
    }


    void OnChooseLevel1()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Level1Scene");

        AudioController.Instance.GetEvent("BeijingKaiChang").stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    void OnChooseLevel2()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Level2Scene");
        AudioController.Instance.GetEvent("BeijingKaiChang").stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    void OnChooseLevel3()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Level3Scene");
        AudioController.Instance.GetEvent("BeijingKaiChang").stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
