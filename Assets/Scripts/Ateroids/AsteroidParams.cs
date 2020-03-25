using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AsteroidParamsScriptableObject", order = 1)]
public class AsteroidParams : ScriptableObject
{
    public float asteroidSpeed;
    public int asteroidHealth;
}

