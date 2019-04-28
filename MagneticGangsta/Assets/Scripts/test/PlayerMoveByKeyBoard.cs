using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByKeyBoard : PlayerFunctionBase
{
    public override string Name { get { return "TestMove"; } }

    public float PlayerForce { get { Move move = Player.FunctionBases["Move"] as Move; return move.PlayerForce; } }
    public float MaxMoveSpeed { get { Move move = Player.FunctionBases["Move"] as Move; return move.PlayerForce; } }

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public override void PlayerInit()
    {
        
    }
    public override void PlayerLoop()
    {
        Moving();
        CheckMoving();
    }

    public void Moving()
    {
        Move move = Player.FunctionBases["Move"] as Move;
        if (!move.FunctionEnable) return;

        float force = 0;
        if (Input.GetKey(left))
        {
            force -= PlayerForce;
        }
        if(Input.GetKey(right))
        {
            force += PlayerForce;
        }
        float joyforce = Input.GetAxis("Move" + Player.ID) * PlayerForce;
        if (joyforce > 0.3)
        {
            return;
        }


        GetComponent<Animator>().SetFloat("MoveSpeed", Mathf.Abs(force));
        if (force < -0.3) Player.transform.localScale = new Vector3(-1, 1, 1);
        if (force > 0.3) Player.transform.localScale = new Vector3(1, 1, 1);


        if (Player.PlayerRigidbody2D.velocity.x > MaxMoveSpeed)
        {
            if (force > 0)
            {
                force = 0;
            }
        }

        if (Player.PlayerRigidbody2D.velocity.x < -MaxMoveSpeed)
        {
            if (force < 0)
            {
                force = 0;
            }
        }
        Player.PlayerRigidbody2D.AddForce(new Vector2(force, 0));
    }

    public void CheckMoving()
    {
        if (Mathf.Abs(Player.PlayerRigidbody2D.velocity.x) >= 0.1)
        {
            Player.IsMoving = true;
        }
        else
        {
            Player.IsMoving = false;
        }
    }
}
