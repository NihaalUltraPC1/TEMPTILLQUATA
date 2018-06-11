using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

   


    public GameObject head;

    public float rothead;
    float yRotation;
    public float Rhead = 1f;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
    }
    
}
