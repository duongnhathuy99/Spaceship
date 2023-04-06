using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner ;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Summoning();
    }
    protected virtual void Summoning()
    {
        if (!isReady) return;
        Summon();
    }
    protected virtual Transform Summon()
    {
        Transform spawnPos = abilities.AbilityObjectCtrl.SpawnPoints.GetRamdom();
        Transform minionPrefab = spawner.RandomPrefab();
        Transform minion = spawner.Spawn(minionPrefab, spawnPos.position, spawnPos.rotation);
        minion.gameObject.SetActive(true);
        Active();
        return minion;
    }
}
