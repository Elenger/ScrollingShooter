using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityFilling : MonoBehaviour
{
    [SerializeField] private int _requiredAmountAsteroids;
    [SerializeField] private Image _imageAbility;
    [SerializeField] private Animator _animatorAbility;
    [SerializeField] private Button _buttonAbility;
    private float _abilityPointsForEachAsteroid;
    public int countWhippedAsteroids;

    // Start is called before the first frame update
    void Start()
    {
        _abilityPointsForEachAsteroid = 1f / _requiredAmountAsteroids;
        _buttonAbility.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbilityIsEnable()
    {
        if (_requiredAmountAsteroids >= countWhippedAsteroids)
        {
            _imageAbility.fillAmount += _abilityPointsForEachAsteroid;
        }
        else
        {
            _animatorAbility.Play("AbilityAnimation");
            _buttonAbility.interactable = true;
        }
    }   
}

