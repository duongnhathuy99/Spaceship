using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearingBigger: ObjAppearing
{
    [Header("Obj Bigger")]
    [SerializeField] protected float speedScale = 0.01f;
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
    protected virtual void OnEnable()
    {
        InitScale();
    }
    protected override void Appearing() 
    {
        currentScale += speedScale;
        transform.parent.localScale = new Vector3(currentScale, currentScale, currentScale);
        if (currentScale >= maxScale) Appear();
    }
    protected virtual void InitScale()
    {
        transform.parent.localScale = Vector3.zero;
        currentScale = startScale;
    }
    public override void Appear() 
    {
        base.Appear();
        transform.parent.localScale = new Vector3(maxScale, maxScale, maxScale);
    }
}
