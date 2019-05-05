using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TauntShow : PlayerFunctionBase
{

    [SerializeField] List<Sprite> m_sprites;

    [SerializeField] GameObject m_bubble;
    [SerializeField] Image m_face;
    [SerializeField] CDBase m_showTime;
    [SerializeField] float m_appearTime;
    // Start is called before the first frame update
    void Start()
    {
        m_showTime.OnTimeOut += ShowEnd;
        m_bubble.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        m_face.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    void ShowEnd()
    {
        m_bubble.GetComponent<Image>().DOFade(0, m_appearTime);
        m_face.GetComponent<Image>().DOFade(0, m_appearTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Taunt" + Player.ID) && m_showTime.CD == 1)
        {
            int chooseFace = Random.Range(0, m_sprites.Count);
            m_face.sprite = m_sprites[chooseFace];
            m_showTime.Start();
            m_bubble.GetComponent<Image>().DOFade(1, m_appearTime);
            m_face.GetComponent<Image>().DOFade(1, m_appearTime);
        }
    }
}
