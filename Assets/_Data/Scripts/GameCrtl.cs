using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCrtl : SaiMonoBehaviour
{
    private static GameCrtl _instance;
    public static GameCrtl Instance { get => _instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }
    protected override void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    protected virtual void LoadCamera() 
    {
        if (mainCamera != null) return;
        mainCamera = GameCrtl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ":Load Camera ", gameObject);
    }
}
