using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour {

    private const float Y_ANGLE_MIN = 0.5f;
    private const float Y_ANGLE_MAX = 50.0f;



    public VirtualJoystick1 cameraJoystick;

    public Transform lookAt;
    //public Transform camTransform;

    private Camera cam;

    public float distance = 10.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    public float sensivityX = 3.0f;
    public float sensivityY = 1.0f;

    private void Start()
    {
       // camTransform = transform;
        //cam = Camera.main;
    }
    
    private void Update()
    {
        currentX -= cameraJoystick.InputDirection.x * sensivityX;
        currentY += cameraJoystick.InputDirection.z * sensivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt);

         //camTransform.position = lookAt.position + rotation * dir;
       // camTransform.LookAt(lookAt.position);

    }


}
