using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Range(0f,50f)]
    public float Speed;

    Rigidbody rb;

    private void Start()
    {
        rb = GameObject.FindObjectOfType<Rigidbody>();
    }

    private void Update()
    {
        RigidbodyMovement();
    }

    void RigidbodyMovement()
    {

        //Move Forward

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, Speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        //Move Backward

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -Speed * Time.deltaTime, ForceMode.VelocityChange);
        }

        //Move Left

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Move Right

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    void VectorMovement()
    {

        //Move Forward

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        //Move Backward

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        //Move Left

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }

        //Move Right

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
    }
}
