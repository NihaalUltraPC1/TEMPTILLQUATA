using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALLROT : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public VirtualJoystick JoyStick; //{ set; get; }

    private Rigidbody thisRigidbody;
    private Transform camTransform;

    private void Start()
    {
        thisRigidbody = gameObject.AddComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;

    }

    private void Update()
    {
        MoveVector = PoolInput();

        MoveVector = RotateWithView();

        Move();
    }

    private void Move()
    {
        thisRigidbody.AddForce((MoveVector * moveSpeed));
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = JoyStick.Horizontal();
        dir.z = JoyStick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;

    }


    private Vector3 RotateWithView()
    {
         if(camTransform != null)
        {
            Vector3 dir = camTransform.TransformDirection(MoveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * MoveVector.magnitude;
        }
        else
        {
            camTransform = Camera.main.transform;

            return MoveVector;
        }

    }


}
