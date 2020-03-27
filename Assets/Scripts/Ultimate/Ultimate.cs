using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private GameObject _bulletCurrently;
    [SerializeField] private GameObject _bulletUltimative;
    public void UseUltimate()
    {
        FirstUltimate();
    }    

    private void FirstUltimate()
    {
        BulletPooler.SharedInstance.SetNewPrefab(_bulletUltimative);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4f);
        BulletPooler.SharedInstance.SetNewPrefab(_bulletCurrently);
    } 
}
