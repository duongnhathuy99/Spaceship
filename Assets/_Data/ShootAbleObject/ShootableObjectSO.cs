using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "Shootable Object";
    public ObjectType objectType;
    public int hpMax = 20;
    public List<DropRate> dropList;
}
