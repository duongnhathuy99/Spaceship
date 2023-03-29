using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRamdom : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float ramdomDelay = 3f;
    [SerializeField] protected float ramdomTimer = 0f;
    [SerializeField] protected float ramdomJunkLimit = 10f;
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
        //JunkSpawning();
    }
    private void FixedUpdate()
    {
        JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (RamdomReachLimit()) return;
        ramdomTimer += Time.fixedDeltaTime;
        if (ramdomTimer < ramdomDelay) return;
        ramdomTimer = 0;

        Transform ramPoint = junkSpawnerCtrl.JunkSpawnPoints.GetRamdom();
        Vector3 pos = ramPoint.position;
        Quaternion rot = transform.rotation;
        Transform junkRamdom = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteorial, pos, rot);
        junkRamdom.gameObject.SetActive(true);
        //Invoke(nameof(JunkSpawning), 5f);
    }
    protected virtual bool RamdomReachLimit() 
    {
        int currentJunk = junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= ramdomJunkLimit;
    }
}
