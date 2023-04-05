using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : SaiMonoBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjAppearObserver> observers =new List<IObjAppearObserver>();
    
    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;
    protected virtual void Start()
    {
        OnAppearStart();
    }
    protected virtual void FixedUpdate()
    {
        Appearing();
    }

    protected abstract void Appearing();
    public virtual void Appear()
    {
        appeared = true;
        isAppearing = false;
        OnAppearFinish();
    }
    public virtual void ObserverAdd(IObjAppearObserver observer) 
    {
        observers.Add(observer);
    }
    protected virtual void OnAppearStart()
    {
        foreach (IObjAppearObserver observer in observers)
        {
            observer.OnAppearStart();
        }
    }
    protected virtual void OnAppearFinish()
    {
        foreach (IObjAppearObserver observer in observers)
        {
            observer.OnAppearFinish();
        }
    }
}
