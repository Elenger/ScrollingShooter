using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionReturnToPool : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void FixedUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_animator.IsInTransition(0))
        {
            gameObject.SetActive(false);
        }
    }
}
