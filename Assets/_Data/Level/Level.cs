using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : SaiMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int levelMax = 99;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;
    public virtual void LevelUp()
    {
        levelCurrent += 1;
        LitmitLevel();
    }
    public virtual void LevelSet(int newLevel)
    {
        levelCurrent = newLevel;
        LitmitLevel();
    }
    protected virtual void LitmitLevel()
    {
        if (levelCurrent > LevelMax) levelCurrent = levelMax;
        if (levelCurrent < 1) levelCurrent = 1;
    }
}
