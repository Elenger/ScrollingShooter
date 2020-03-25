using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInfo : MonoBehaviour
{
    [SerializeField] private AsteroidParams _params;
    public int health;
    public GameObject explosionPrefab;

    private void OnEnable()
    {
        health = _params.asteroidHealth;
    }

    public void CheckHealth()
    {
        if (health < 1)
        {
            SpawnExplosion();
            gameObject.SetActive(false);
        }
    }

    private void SpawnExplosion()
    {
        GameObject explosion = ExplosionPooler.SharedInstance.GetPooledObject();
        if (explosion != null)
        {
            explosion.transform.position = transform.position;
            explosion.transform.rotation = transform.rotation;
            explosion.SetActive(true);
        }
    }

}
