using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtMouse: ObjLookAtTarget
{
    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected virtual void GetMousePosition()
    {
        targetPosition = InputManager.Instance.MouseWorldPosition;
        targetPosition.z = 0;
    }
   
}
