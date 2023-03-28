using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpwaner();
    }
    protected virtual void LoadJunkSpwaner() 
    {
        if (junkSpawner != null) return;
        junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ":Load JunkSpawner ", gameObject);
    }
}
