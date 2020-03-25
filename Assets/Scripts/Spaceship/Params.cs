using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceshipParamsScriptableObject", order = 1)]
public class Params: ScriptableObject
{
    public int moveSpeed;
}
