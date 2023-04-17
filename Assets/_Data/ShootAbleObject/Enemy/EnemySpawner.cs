using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : Spawner
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get => _instance; }

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = base.Spawn(prefab, spawnPos, rotation);
        AddHPBarToObj(newPrefab);
        return newPrefab;
    }
    protected virtual void AddHPBarToObj(Transform newEnemy) 
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHPBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHPBar.gameObject.SetActive(true);
    }
}
