using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ParentFly
{
    protected override void ResetValue() 
    {
        moveSpeed = 10f;
    }
}
