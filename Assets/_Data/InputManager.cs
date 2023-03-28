using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager _instance;
    public static InputManager Instance { get => _instance; }

    [SerializeField] protected Vector3 mouseWorldPosition;
    public Vector3 MouseWorldPosition { get => mouseWorldPosition; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }
    private void Awake()
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
    void Update()
    {
        this.GetMouseDown();
    }
    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMouseDown()
    {
        onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos() 
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
