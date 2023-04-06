using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot: ShootableObjectAbstract,IObjAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjAppearing objAppearing;
    protected virtual void OnEnable()
    {
        RegisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjAppearing();
    }
    protected virtual void LoadObjAppearing()
    {
        if (objAppearing != null) return;
        objAppearing = GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": Load ObjAppearing ", gameObject);
    }
    protected virtual void RegisterAppearEvent() 
    {
        objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
        shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);
        shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}
