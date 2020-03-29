using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private AsteroidInfo _asteroidInfo;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            _asteroidInfo.health = _asteroidInfo.health - collision.GetComponent<BulletInfo>().bulletDamage;
            _asteroidInfo.CheckHealth();
            
            collision.gameObject.SetActive(false);
        }
    }
}
