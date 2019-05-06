using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundCheck : PlayerFunctionBase
{
    public override string Name { get { return "GroundCheckTest"; } }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Player.OnGround?.Invoke();
        }
    }
}
