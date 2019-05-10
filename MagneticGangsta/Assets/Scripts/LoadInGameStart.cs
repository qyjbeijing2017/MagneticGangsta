using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInGameStart : MonoBehaviour
{
    [SerializeField]AudioController audioController;

    private void Awake()
    {
        AudioController audioControllerInScene = FindObjectOfType<AudioController>();

        if(audioControllerInScene == null)
        {
            Instantiate(audioController);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
