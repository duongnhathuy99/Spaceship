using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    protected override void ResetValue()
    {
        moveSpeed = 0.5f;
    }
}
