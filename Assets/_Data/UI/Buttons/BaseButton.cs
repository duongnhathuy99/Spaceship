using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class BaseButton : SaiMonoBehaviour
{
    [Header("Base button")]
    [SerializeField] protected Button button;

    protected virtual void Start()
    {
        AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadButton();
    }
    protected virtual void LoadButton() 
    {
        if (button != null) return;
        button = GetComponent<Button>();
        Debug.Log(transform.name + ":Load button", gameObject);
    }
    protected virtual void AddOnClickEvent()
    {
        button.onClick.AddListener(OnClick);
    }
    protected abstract void OnClick();
}
