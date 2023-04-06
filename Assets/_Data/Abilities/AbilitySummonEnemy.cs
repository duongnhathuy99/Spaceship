using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [Header("Summon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 4;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ClearDeadMinion();
    }
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
    protected override void Summoning()
    {
        if (minions.Count >= minionLimit) return;
        base.Summoning();
    }
    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);
        return minion;
    }
    protected virtual void ClearDeadMinion()
    {
        foreach (Transform minion in minions)
        {
            if (minion.gameObject.activeSelf == false)
            {
                minions.Remove(minion);
                return;
            }
        }
    }
}
