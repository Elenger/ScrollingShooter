using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPooler : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Stack<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    private Dictionary<string, Stack<GameObject>> _stackBulletsPolls = new Dictionary<string, Stack<GameObject>>();
    private Transform _poolTransform;
    private Dictionary<string, Transform> _transformPoolBullets = new Dictionary<string, Transform>();
    public static BulletPooler SharedInstance;

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

    private void CreateNewObject()
    {
        string name = objectToPool.name;
        GameObject obj = (GameObject)Instantiate(objectToPool);
        obj.transform.SetParent(_transformPoolBullets[name]);
        obj.name = name;
        obj.SetActive(false);
        pooledObjects.Push(obj);
    }
    public GameObject GetPooledObject()
    {
        if (pooledObjects.Count>0) 
        {
            return pooledObjects.Pop();
        }

        CreateNewObject();
        return pooledObjects.Pop();
    }

    public void SetNewPrefab(GameObject prefab)
    {
        objectToPool = prefab;
        if (!_stackBulletsPolls.TryGetValue(objectToPool.name, out pooledObjects))
        {
            PoolFilling();
        }
        pooledObjects = _stackBulletsPolls[objectToPool.name];
    }

    public void PoolFilling()
    {
        string name = objectToPool.name;
        GameObject poolCurrentBullets = new GameObject(name);
        poolCurrentBullets.transform.SetParent(_poolTransform);
        _transformPoolBullets.Add(poolCurrentBullets.name, poolCurrentBullets.transform);

        pooledObjects = new Stack<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            CreateNewObject();
        }

        _stackBulletsPolls.Add(name, pooledObjects);
    }

    public void ReturnToPool(GameObject obj)
    {
        _stackBulletsPolls[obj.name].Push(obj);
    }
}
