using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    [SerializeField] private GameObject _expSpaceshipPrefab;
    [SerializeField] private GameObject _spaceship;
    [SerializeField] private AudioSource _explosionAudioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ExplosionInstantiate();
        //Destroy(gameObject);
    }

    private void ExplosionInstantiate()
    {
        _explosionAudioSource.Play();
        GameObject explosion = Instantiate(_expSpaceshipPrefab);
        explosion.transform.position = transform.position;
    }
    
}
