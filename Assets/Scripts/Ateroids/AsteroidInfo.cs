using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInfo : MonoBehaviour
{
    [SerializeField] private AsteroidParams _params;
    public AbilityFilling _abilityFilling;
    public GameObject explosionPrefab;
    public int health;
    private Animator[] _animatorsArray;
    private Animator _animator;

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }


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
            _animator.Play("DefaultState");
            gameObject.SetActive(false);
        }
    }

    public void SpawnExplosion()
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
