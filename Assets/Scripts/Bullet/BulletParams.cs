using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletParamsScriptableObject", order = 1)]
    public class BulletParams : ScriptableObject
    {
        public int bulletSpeed;
        public int bulletDamage;
    }

