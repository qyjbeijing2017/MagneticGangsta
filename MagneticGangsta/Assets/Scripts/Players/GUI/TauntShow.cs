using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TauntShow : PlayerFunctionBase
{

    [SerializeField] List<Sprite> m_sprites;

    [SerializeField] GameObject m_bubble;
    [SerializeField] Image m_face;
    [SerializeField] CDBase m_showTime;
    // Start is called before the first frame update
    void Start()
    {
        m_showTime.OnTimeOut += ShowEnd;
        m_bubble.SetActive(false);
    }

    void ShowEnd()
    {
        m_bubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Taunt"+ Player.ID) && m_showTime.CD == 1)
        {
            m_bubble.SetActive(true);
            int chooseFace = Random.Range(0, m_sprites.Count);
            m_face.sprite = m_sprites[chooseFace];
            m_showTime.Start();
        }
    }
}
