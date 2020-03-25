using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Collider2D distance;
    [SerializeField] private GameObject _explosionPrefab;

    void Start()
    {
        StartCoroutine(CallSpawnAsteroid());
    }

    private void SpawnAsteroid()
    {
        GameObject asteroid = AsteroidPooler.SharedInstance.GetPooledObject();
        if (asteroid != null)
        {
            asteroid.transform.position = new Vector2(Random.Range(-7, 7), 8);
            asteroid.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
            asteroid.GetComponent<AsteroidReturnToPool>().distance = distance;
            asteroid.SetActive(true);
        }
    }

    private IEnumerator CallSpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(_duration);
            SpawnAsteroid();
        }
    }
}
