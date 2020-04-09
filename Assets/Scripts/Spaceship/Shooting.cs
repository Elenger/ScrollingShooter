using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    [SerializeField] private Collider2D _distance;
    private float _reloadCounter;
    public GameObject bulletPrefab;

    void FixedUpdate()
    {
        _reloadCounter += Time.deltaTime;
        if (_reloadCounter > _reloadTime)
        {
            _reloadCounter -= _reloadTime;
            Shot();
        }
    }

    private void Shot()
    {
        GameObject bullet = BulletPooler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<BulletReturnToPool>().distance = _distance;
            bullet.SetActive(true);
        }
    }
}
