using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarpFromInput: AbilityWarp
{
    //[Header(" Warp From Input")]
    protected override void Update()
    {
        base.Update();
        UpdateKeyDirection();
    }

    protected virtual void UpdateKeyDirection()
    {
        KeyDirection = InputManager.Instance.Direction;
    }
}
