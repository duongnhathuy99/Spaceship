using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : SaiMonoBehaviour
{
    private static UIInventory _instance;
    public static UIInventory Instance { get => _instance; }

    protected bool isOpen = true;
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    protected virtual void Start()
    {
        Toggle();
    }
    public virtual void Toggle()
    {
        isOpen = !isOpen;
        if (isOpen) Open();
        else Close();
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
    protected virtual void ShowItem()
    {
        if (!isOpen) return;
        float itemCount = PlayerCtrl.Instance.CurrentShip.Inventory.Items.Count;
        Debug.Log("Count item:" + itemCount);
    }   
}
