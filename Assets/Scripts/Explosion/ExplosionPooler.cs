using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionPooler : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    public static ExplosionPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        GameObject poolExplosions = new GameObject("PoolExplosions");
        poolExplosions.transform.SetParent(_parent.transform);
        Transform poolTransform = poolExplosions.transform;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.transform.SetParent(poolTransform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
