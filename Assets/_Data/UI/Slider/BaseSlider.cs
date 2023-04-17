using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : SaiMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected virtual void Start()
    {
        AddOnClickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = GetComponent<Slider>();
        Debug.Log(transform.name + ":Load Slider", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        slider.onValueChanged.AddListener(OnChanged);
    }
    protected abstract void OnChanged(float newValue);
}
