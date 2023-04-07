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

    [SerializeField] protected Vector4 direction;
    public Vector4 Direction { get => direction; }
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
        this.GetDirectionKeyDown();
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
    protected virtual void GetDirectionKeyDown()
    {
        direction.x = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;
        direction.y = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;
        direction.z = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        direction.w = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;

        /*if (direction.x == 1) Debug.Log("Left");
        if (direction.y == 1) Debug.Log("Right");
        if (direction.z == 1) Debug.Log("Up");
        if (direction.w == 1) Debug.Log("Down");*/
    }
}
