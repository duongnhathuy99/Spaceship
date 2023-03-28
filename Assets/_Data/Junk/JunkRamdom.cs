using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRamdom : SaiMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {

        LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ":Load JunkCtrl ", gameObject);
    }
    protected void Start()
    {
        JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform junkRamdom = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteorial, pos, rot);
        junkRamdom.gameObject.SetActive(true);
        Invoke(nameof(JunkSpawning), 1f);
    }
}
