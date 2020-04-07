using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] private AbilityFilling _abilityFilling;
    [SerializeField] private AsteroidPooler _poolerAsteroid;
    [SerializeField] private Animator _animatorAbility;
    [SerializeField] private Button _buttonAbility;
    [SerializeField] private Image _imageAbility;

    public void UseAbility()
    {
        _buttonAbility.interactable = false;
        _imageAbility.fillAmount = 0f;
        _abilityFilling.countWhippedAsteroids = 0;
        _animatorAbility.Play("Stop");

        _poolerAsteroid.ReturnAll();
    }
}
