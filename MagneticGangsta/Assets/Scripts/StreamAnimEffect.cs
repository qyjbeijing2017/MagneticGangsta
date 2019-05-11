using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamAnimEffect : MonoBehaviour
{

    [SerializeField]Animator animator;
    [SerializeField] float waitSecond = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        animator.speed = 0;
        yield return new WaitForSeconds(waitSecond);
        animator.speed = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
