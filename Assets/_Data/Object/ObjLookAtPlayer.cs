using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer: ObjLookAtTarget
{
    [Header("Look at player")]
    [SerializeField] protected GameObject player;
    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.FindWithTag("Player");
        Debug.Log(transform.name + ": Load Player ", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        if (player == null) return;
        targetPosition = player.transform.position;
        targetPosition.z = 0;
    }
   
}
