using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speedRotate = 20;
    private void FixedUpdate()
    {
        Rotating();
    }
    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0, 1);
        //transform.parent.Rotate(eulers * speedRotate * Time.deltaTime);
        junkCtrl.Model.Rotate(eulers * speedRotate * Time.deltaTime);
    }
}
