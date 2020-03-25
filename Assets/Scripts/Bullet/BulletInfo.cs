using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    [SerializeField] private BulletParams _bulletParams;

    private int _bulletSpeed;
    public int bulletDamage;

    private void Start()
    {
        _bulletSpeed = _bulletParams.bulletSpeed;
        bulletDamage = _bulletParams.bulletDamage;
    }

}
