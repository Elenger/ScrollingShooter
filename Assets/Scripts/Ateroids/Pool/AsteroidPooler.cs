using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidPooler : MonoBehaviour
{
    [SerializeField] private AbilityFilling _abilityFilling;
    [SerializeField] private AudioSource _explosionAudioSource;
    [SerializeField] private Transform _parent;
    public static AsteroidPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        GameObject poolAsteroids = new GameObject("PoolAsteroids");
        poolAsteroids.transform.SetParent(_parent.transform);
        Transform poolTransform = poolAsteroids.transform;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool[Random.Range(0,3)]);
            obj.SetActive(false);
            obj.transform.SetParent(poolTransform);
            AsteroidInfo asteroidInfo = obj.GetComponent<AsteroidInfo>();
            asteroidInfo.explosionAudioSource = _explosionAudioSource;
            asteroidInfo._abilityFilling = _abilityFilling;
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

    public void ReturnAll()
    {
        foreach (GameObject asteroid in pooledObjects)
        {
            asteroid.GetComponent<AsteroidInfo>().SpawnExplosion();
            asteroid.SetActive(false);
        }
    }
}
