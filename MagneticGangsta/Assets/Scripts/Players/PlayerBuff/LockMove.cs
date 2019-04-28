using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMove : PlayerBuffBase
{
    public override string Name { get { return "LockMove"; } }


    public override void StartBefore(BuffAttributesData buffAttributes)
    {
        base.StartBefore(buffAttributes);
        MaxTime.OnTimeOut -= EndBefore;
    }
    

    public override void BuffStart(BuffAttributesData buffAttributes)
    {
        buffAttributes.IsLockMove.AddBuffEffect(Name, (attribute, attributeBase) => { return false; });
    }

    public override void BuffEnd(BuffAttributesData buffAttributes)
    {
        buffAttributes.IsLockMove.RemoveBuffEffect(Name);
    }
}
