using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TEST_MOVE1 : MonoBehaviour
{

	
               //  public float walkSpeed = 10;
               //  public float rotateSpeed = 175;
               //  public float jumpHeight = 50;


    public GameObject camera;

    public float RotateSpeed = 30f;

   

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      



        if (Input.GetKey(KeyCode.Q))
            camera.transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            camera.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);

    }

   // private void Update()
   // {
        /*
        //Moves Player Foward
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);


        //Moves Player Back
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * walkSpeed);

        //Moves Player Right
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * walkSpeed);

        //Moves Player Left
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * walkSpeed);

        //Rotates Player Right
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

        //Rotates Plater Left
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);

        //Player Jumps
        if (Input.GetKeyDown("space"))
            transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
    */




    
    
    
   // }

            
                 
             
                 
             
         
     
}
