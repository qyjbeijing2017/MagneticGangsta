using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : PlayerBuffBase
{
    public override string Name { get { return "Delay"; } }
    // Start is called before the first frame update
    public Delay(float delayTime)
    {
        MaxTime.CDTime = delayTime;
    }

    public override void BuffStart(BuffAttributesData buffAttributes)
    {
        buffAttributes.IsLockOption.AddBuffEffect(Name, (attribute, attributeBase) => { return true; });
    }

    public override void BuffEnd(BuffAttributesData buffAttributes)
    {
        buffAttributes.IsLockOption.RemoveBuffEffect(Name);
    }
}
