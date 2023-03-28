using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{
    
    protected virtual void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void Awake()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void LoadComponents()
    {
    
    }
    protected virtual void ResetValue()
    {

    }
}
