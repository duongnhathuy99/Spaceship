using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseText : SaiMonoBehaviour
{
    [Header("Base text")]
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadText();
    }
    protected virtual void LoadText()
    {
        if (text != null) return;
        text = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ":Load Text", gameObject);
    }
}
