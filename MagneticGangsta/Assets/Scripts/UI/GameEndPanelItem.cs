using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndPanelItem : MonoBehaviour
{
    [SerializeField]Text m_score;
    [SerializeField]Transform m_playerIconTrans;
    GameObject m_playerIcon;

    public void ItemInit(GameObject icon, int score, Color scoreColor)
    {
        m_score.text = score.ToString();
        m_score.color = scoreColor;
        if(m_playerIcon != null)
        {
            Destroy(m_playerIcon);
        }
        m_playerIcon = Instantiate(icon, m_playerIconTrans, false);
    }


}
