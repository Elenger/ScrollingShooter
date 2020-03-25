using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private Params _params;
    private int _moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = _params.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        transform.Translate(vectorMovement.normalized * _moveSpeed * Time.deltaTime);
    }
}
