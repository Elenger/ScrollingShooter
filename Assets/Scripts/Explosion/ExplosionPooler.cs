using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionPooler : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Stack<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    private Transform _poolTransform;
    public static ExplosionPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        GameObject poolExplosions = new GameObject("PoolExplosions");
        poolExplosions.transform.SetParent(_parent.transform);
        _poolTransform = poolExplosions.transform;

        pooledObjects = new Stack<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            CreateNewObject();
        }

    }

    private void CreateNewObject()
    {
        GameObject obj = (GameObject)Instantiate(objectToPool);
        obj.transform.SetParent(_poolTransform);
        obj.SetActive(false);
        pooledObjects.Push(obj);
    }

    public GameObject GetPooledObject()
    {
        if (pooledObjects.Count > 0)
        {
            return pooledObjects.Pop();
        }

        CreateNewObject();
        return pooledObjects.Pop();
    }

    public void ReturnToPool(GameObject obj)
    {
        pooledObjects.Push(obj);
    }
}
