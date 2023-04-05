using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner { get => spawner; }

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => spawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpwaner();
        LoadSpawnPoints();
    }
    protected virtual void LoadSpwaner() 
    {
        if (spawner != null) return;
        spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ":Load spawner ", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = Transform.FindAnyObjectByType<SpawnPoints>();
        Debug.Log(transform.name + ":Load spawnPoints ", gameObject);
    }
}
