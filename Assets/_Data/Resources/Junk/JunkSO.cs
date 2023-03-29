using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="junk", menuName = "ScriptableObject/Junk")]
public class JunkSO : ScriptableObject
{
    public string junkName = "Junk";
    public int hpMax = 20;
}
