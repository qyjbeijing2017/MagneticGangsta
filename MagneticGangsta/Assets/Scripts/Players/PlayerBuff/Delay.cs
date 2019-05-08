using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : PlayerBuffBase
{
    public override string Name { get { return "Delay"; } }
    // Start is called before the first frame update

    private Vector2 velocity;
    private Vector3 position;
    public Delay(float delayTime)
    {
        MaxTime.CDTime = delayTime;
    }

    public override void BuffStart(BuffAttributesData buffAttributes)
    {
        buffAttributes.IsLockMove.AddBuffEffect(Name, (attribute, attributeBase) => { return false; });

        buffAttributes.AnimatorSpeed.AddBuffEffect(Name, (attribute, attributeBase) => { return 0.1f; });

        velocity = BuffManager.Player.PlayerRigidbody2D.velocity;

        BuffManager.Player.PlayerRigidbody2D.velocity = Vector2.zero;

        position = BuffManager.Player.transform.position;

    }

    public override void BuffEnd(BuffAttributesData buffAttributes)
    {
        buffAttributes.IsLockMove.RemoveBuffEffect(Name);
        buffAttributes.AnimatorSpeed.RemoveBuffEffect(Name);
        BuffManager.Player.PlayerRigidbody2D.velocity = velocity;
    }

    public override void Update()
    {
        BuffManager.Player.transform.position = position;
        velocity += BuffManager.Player.PlayerRigidbody2D.velocity;
        BuffManager.Player.PlayerRigidbody2D.velocity = Vector2.zero;
    }
}
