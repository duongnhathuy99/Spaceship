using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    //[Header("Summon Enemy")]
    //[SerializeField] protected Spawner spawner ;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + "Load enemySpawner", gameObject);
    }
}
