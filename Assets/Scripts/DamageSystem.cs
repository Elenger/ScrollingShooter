using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private AsteroidInfo _asteroidInfo;
    private Animator[] _animatorsArray;
    private Animator _animator;

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            _asteroidInfo.health = _asteroidInfo.health - collision.GetComponent<BulletInfo>().bulletDamage;
            
            if (!_animator.GetCurrentAnimatorStateInfo(0) .IsName("AsteroidShake"))
            {
                _animator.Play("AsteroidShake");
                _animator.SetBool("StopAnimation", true);
            }
            _asteroidInfo.CheckHealth();
            collision.gameObject.SetActive(false);
        }
    }
}
