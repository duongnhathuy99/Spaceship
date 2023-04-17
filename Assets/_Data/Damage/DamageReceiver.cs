using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : SaiMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp;
    [SerializeField] protected int hpmax = 40;
    [SerializeField] protected bool isDead = false;
    public int HP => hp;
    public int HPMax => hpmax;
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
    public virtual void Add(int add)
    {
        hp += add;
        if (hp > hpmax) hp = hpmax;
    }
    public virtual void Deduct(int deduct)
    {
        hp -= deduct;
        if (hp < 0) hp = 0;
        CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }
    protected abstract void OnDead();
}
