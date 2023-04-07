using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : SaiMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;

    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    protected virtual void FixedUpdate()
    {
        Timing();
    }
    protected virtual void Update()
    {
       
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (abilities != null) return;
        abilities = transform.parent.GetComponent<Abilities>();
        Debug.Log(transform.name + "Load abilities", gameObject);
    }
    protected virtual void Timing()
    {
        if (isReady) return;
        timer += Time.fixedDeltaTime;
        if (timer < delay) return;
        isReady = true;
    }
    public virtual void Active()
    {
        isReady = false;
        timer = 0;
    }
}
