using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : SaiMonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float hpmax = 40;
    [SerializeField] protected bool isDead = false;
    private void OnEnable()
    {
        Reborn();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        Reborn();
    }
    protected virtual void Reborn() 
    {
        hp = hpmax;
    }
    public virtual void Add(float add)
    {
        hp += add;
        if (hp > hpmax) hp = hpmax;
    }
    public virtual void Deduct(float deduct)
    {
        hp -= deduct;
        if (hp < 0) hp = 0;
        CheckIsDead();
    }
    protected virtual bool IsDead()
    {
        return hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }
    protected virtual void OnDead()
    {
       
    }
}
