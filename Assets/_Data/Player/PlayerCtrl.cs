using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : SaiMonoBehaviour
{
    private static PlayerCtrl _instance;
    public static PlayerCtrl Instance => _instance;

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip { get => currentShip; }

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup { get => playerPickup; }

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null) Destroy(gameObject);
        else _instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup() 
    {
        if (playerPickup != null) return;
        playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ":Load PlayerPickup ", gameObject);
    }
}
