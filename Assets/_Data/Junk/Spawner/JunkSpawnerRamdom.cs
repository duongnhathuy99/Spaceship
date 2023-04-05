using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRamdom : SaiMonoBehaviour
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float ramdomDelay = 3f;
    [SerializeField] protected float ramdomTimer = 0f;
    [SerializeField] protected float ramdomJunkLimit = 10f;
    protected override void LoadComponents()
    {
        LoadSpawnerCtrl();
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (spawnerCtrl != null) return;
        spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ":Load SpawnerCtrl ", gameObject);
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

        Transform ramPoint = spawnerCtrl.SpawnPoints.GetRamdom();
        Vector3 pos = ramPoint.position;
        Quaternion rot = transform.rotation;
        Transform prefab = this.spawnerCtrl.Spawner.RandomPrefab();
        Transform enemyRamdom = this.spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
        enemyRamdom.gameObject.SetActive(true);
        //Invoke(nameof(JunkSpawning), 5f);
    }
    protected virtual bool RamdomReachLimit() 
    {
        int currentJunk = spawnerCtrl.Spawner.SpawnedCount;
        return currentJunk >= ramdomJunkLimit;
    }
}
