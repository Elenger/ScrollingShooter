using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private float _duration;
    [SerializeField] private Collider2D _distance;

    // Start is called before the first frame update
    void Start()
    {     
        StartCoroutine(CallShotIntime());
    }

    // Update is called once per frame
    private void Shot()
    {
        GameObject bullet = BulletPooler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<BulletReturnToPool>().distance = _distance;
            bullet.SetActive(true);
        }
    }


    private IEnumerator CallShotIntime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_duration);
            Shot();
        }      
    }
}
