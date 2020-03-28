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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAbility()
    {
        _buttonAbility.interactable = false;
        _imageAbility.fillAmount = 0f;
        _abilityFilling.countWhippedAsteroids = 0;
        _animatorAbility.Play("Stop");

        _poolerAsteroid.ReturnAll();
    }
}
