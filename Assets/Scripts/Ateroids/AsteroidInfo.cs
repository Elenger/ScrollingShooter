using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInfo : MonoBehaviour
{
    [SerializeField] private AsteroidParams _params;
    public AbilityFilling _abilityFilling;
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

            _abilityFilling.countWhippedAsteroids += 1;
            _abilityFilling.AbilityIsEnable();

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
