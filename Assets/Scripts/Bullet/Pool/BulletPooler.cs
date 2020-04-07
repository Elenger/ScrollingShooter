using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPooler : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private Transform _poolTransform;
    public static BulletPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        GameObject poolBullets = new GameObject("PoolBullets");
        poolBullets.transform.SetParent(_parent.transform);
        _poolTransform = poolBullets.transform;

        PoolFilling();
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

    public void SetNewPrefab(GameObject prefab)
    {
        objectToPool = prefab;
        PoolFilling();
    }

    public void PoolFilling()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.transform.SetParent(_poolTransform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
}
