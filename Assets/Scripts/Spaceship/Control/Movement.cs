using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Movement : MonoBehaviour
{

    [SerializeField] private Params _params;
    private int _moveSpeed;
    private Vector3 cameraCondition;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        _moveSpeed = _params.moveSpeed;
        cameraCondition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        //  Vector3 vectorMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        //  transform.Translate(vectorMovement.normalized * _moveSpeed * Time.deltaTime);

        //Quaternion deviceRotation = DeviceRotation.Get();
        //transform.rotation = deviceRotation;
        // transform.Translate(transform.up * _moveSpeed);

        Vector3 vectorGyroMovement = new Vector3(Input.gyro.rotationRateUnbiased.x, 0f, 0f);
        transform.Translate(vectorGyroMovement * _moveSpeed * Time.deltaTime);

        SpaceshipScreen();
    }

    private void SpaceshipScreen()
    {
        if (transform.position.x < -cameraCondition.x)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = cameraCondition.x;
            transform.position = newPosition;
        } 
        else if (transform.position.x > cameraCondition.x)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = -cameraCondition.x;
            transform.position = newPosition;
        }
    }
}
