using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRamdom : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;

    protected override void LoadComponents()
    {
        LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkSpawnerCtrl != null) return;
        junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ":Load JunkSpawnerCtrl ", gameObject);
    }
    
    protected void Start()
    {
        JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        Transform ramPoint = junkSpawnerCtrl.JunkSpawnPoints.GetRamdom();
        Vector3 pos = ramPoint.position;
        Quaternion rot = transform.rotation;
        Transform junkRamdom = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteorial, pos, rot);
        junkRamdom.gameObject.SetActive(true);
        Invoke(nameof(JunkSpawning), 1f);
    }
}
