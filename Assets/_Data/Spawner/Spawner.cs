using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjects;

    protected override void LoadComponents()
    {
        LoadPrefabs();
        LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        Debug.Log(transform.name + ":Load holder ", gameObject);
    }
    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        HidePrefabs();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName,Vector3 spawnPos,Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null) 
        {
            Debug.LogWarning("Prefab spawn not found "+ prefabName);
            return null; 
        }

        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        //newPrefab.parent = holder;
        spawnedCount++;
        return newPrefab;
    }
    public virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObject in poolObjects)
        {
            if (poolObject.name == prefab.name) 
            {
                poolObjects.Remove(poolObject);
                return poolObject;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        newPrefab.parent = holder;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj) 
    {
        poolObjects.Add(obj);
        obj.gameObject.SetActive(false);
        spawnedCount--;
    }
    public virtual Transform GetPrefabByName(string prefabName) 
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
}
