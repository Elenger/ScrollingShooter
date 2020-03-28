using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    [SerializeField] private GameObject _expSpaceshipPrefab;
    [SerializeField] private GameObject _spaceship;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ExplonationInstantiate();
        //Destroy(gameObject);
    }

    public void ExplonationInstantiate()
    {
        
        Instantiate(_expSpaceshipPrefab);
//        Vector3 v3ExpOne = transform.position, v3ExpTwo = transform.position, v3ExpThree = transform.position;
//
//        v3ExpOne = new Vector2(v3ExpOne.x - 1, v3ExpOne.y);
//        v3ExpTwo = new Vector2(v3ExpTwo.x + 1, v3ExpTwo.y);
//        v3ExpThree = new Vector2(v3ExpThree.x, v3ExpThree.y+1);
//
//        GameObject expOne = Instantiate(_expSpaceshipPrefab);  
//        GameObject expTwo =  Instantiate(_expSpaceshipPrefab);
//        GameObject expThree =  Instantiate(_expSpaceshipPrefab);
//
//        expOne.transform.position = v3ExpOne;
//        expTwo.transform.position = v3ExpTwo;
//        expThree.transform.position = v3ExpThree;
    }
    
}
