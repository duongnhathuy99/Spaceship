using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 70;

    protected virtual void FixedUpdate() 
    {
        HPShowing();
    }
    protected virtual void HPShowing()
    {
        float hpPercent = currentHP / maxHP;
        slider.value = hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
        //Debug.Log("new value " + newValue);
    }

    public virtual void SetMaxHp(float maxHP)
    {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHp(float currentHP)
    {
        this.currentHP = currentHP;
    }
}
