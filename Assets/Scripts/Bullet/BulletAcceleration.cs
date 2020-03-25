using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAcceleration : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private BulletParams _params;

    private void OnEnable()
    {
        _rb2D.velocity = new Vector2(0, _params.bulletSpeed);
    }
}
