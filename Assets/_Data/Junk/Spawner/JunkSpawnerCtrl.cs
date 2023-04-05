using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => spawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpwaner();
        LoadSpawnPoints();
    }
    protected virtual void LoadJunkSpwaner() 
    {
        if (junkSpawner != null) return;
        junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ":Load JunkSpawner ", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = Transform.FindAnyObjectByType<SpawnPoints>();
        Debug.Log(transform.name + ":Load spawnPoints ", gameObject);
    }
}
