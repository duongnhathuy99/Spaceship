using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints { get => junkSpawnPoints; }
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
        if (junkSpawnPoints != null) return;
        junkSpawnPoints = Transform.FindAnyObjectByType<JunkSpawnPoints>();
        Debug.Log(transform.name + ":Load JunkSpawnPoints ", gameObject);
    }
}
