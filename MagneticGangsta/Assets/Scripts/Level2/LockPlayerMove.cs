using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerMove : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBuffManager playerBuffManager = collision.GetComponent<PlayerBuffManager>();
        if(playerBuffManager != null)
        {
            playerBuffManager.AddBuff(new LockMove());
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerBuffManager playerBuffManager = collision.GetComponent<PlayerBuffManager>();
        if (playerBuffManager != null)
        {
            playerBuffManager.RemoveBuff(new LockMove().Name);
        }
    }
}
