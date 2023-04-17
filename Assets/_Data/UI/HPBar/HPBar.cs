using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : SaiMonoBehaviour
{
    [Header("HP")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSliderHP();
        LoadFollowTarget();
        LoadSpawner();
    }
    protected virtual void FixedUpdate()
    {
        HPShowing();
    }

    protected virtual void LoadSliderHP()
    {
        if (sliderHP != null) return;
        sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.Log(transform.name + ":Load SliderHP", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (followTarget != null) return;
        followTarget = transform.GetComponent<FollowTarget>();
        Debug.Log(transform.name + ":Load FollowTarget", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.Log(transform.name + ":Load SliderHP", gameObject);
    }

    protected virtual void HPShowing()
    {
        if (shootableObjectCtrl == null) return;
        bool isDead = shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            spawner.Despawn(transform);
            return;
        }

        float hp = shootableObjectCtrl.DamageReceiver.HP;
        float hpMax = shootableObjectCtrl.DamageReceiver.HPMax;

        sliderHP.SetMaxHp(hpMax);
        sliderHP.SetCurrentHp(hp);
    }
    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        followTarget.SetTarget(target);
    }
}
