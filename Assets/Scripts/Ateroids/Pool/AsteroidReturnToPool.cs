using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidReturnToPool : MonoBehaviour
{
    public Collider2D distance;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == distance)
        {
            gameObject.SetActive(false);
        }
    }
}
