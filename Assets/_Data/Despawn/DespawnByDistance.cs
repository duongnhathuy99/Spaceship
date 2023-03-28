using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponents()
    {
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + "LoadCamera:"+ gameObject);
    }
   
    protected override bool CanDesSpawn()
    {
        distance = Vector3.Distance(transform.position, mainCam.transform.position);
        if (distance > disLimit) return true;
        else return false;
    }
}
