using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidPooler : MonoBehaviour
{
    [SerializeField] private AbilityFilling _abilityFilling;
    [SerializeField] private AudioSource _explosionAudioSource;
    [SerializeField] private Transform _parent;
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private GameObject[] objectToPool;
    [SerializeField] private int amountToPool;
    private Transform _poolTransform;
    public static AsteroidPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        GameObject poolAsteroids = new GameObject("PoolAsteroids");
        poolAsteroids.transform.SetParent(_parent.transform);
        _poolTransform = poolAsteroids.transform;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool[Random.Range(0,3)]);
            obj.SetActive(false);
            obj.transform.SetParent(_poolTransform);
            AsteroidInfo asteroidInfo = obj.GetComponent<AsteroidInfo>();
            asteroidInfo.explosionAudioSource = _explosionAudioSource;
            asteroidInfo._abilityFilling = _abilityFilling;
            pooledObjects.Add(obj);
        }
    }

    private void CreateNewObject()
    {
        GameObject obj = (GameObject)Instantiate(objectToPool[Random.Range(0, 3)]);
        obj.SetActive(false);
        obj.transform.SetParent(_poolTransform);
        AsteroidInfo asteroidInfo = obj.GetComponent<AsteroidInfo>();
        asteroidInfo.explosionAudioSource = _explosionAudioSource;
        asteroidInfo._abilityFilling = _abilityFilling;
        pooledObjects.Add(obj);
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
