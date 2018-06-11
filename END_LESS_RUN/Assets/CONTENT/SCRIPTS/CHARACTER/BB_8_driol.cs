using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;


public class BB_8_driol : MonoBehaviour {

    //public JoyDpad joyDpad;
    public VirtualJoystick joystick;

    public GameObject head;

    public int speed = 10;

    public float Rhead = 1f;
    float yRotation;
    public float rothead = 10;

	
	

	void FixedUpdate () {

        //float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

         float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");

        // float h = joyDpad.Horizontal();
        // float v = joyDpad.Vertical();

        //float x = joystick.Horizontal();
        //float z = joystick.Vertical();



        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * v);
        GetComponent<Rigidbody>().AddForce(Vector3.right * speed * h);

        if(h==0 && v==0)
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        //-6.69 - -173.35
        /*
        if (h!=0)
        {
            yRotation += h * rothead;
            yRotation = Mathf.Clamp(yRotation ,-172 , -7);

            head.transform.eulerAngles = new Vector3(0, yRotation, 0);

        }
        */
      

       /* if (v!= 0)
        {
            yRotation += v * rothead;
            yRotation = Mathf.Clamp(yRotation, 90, 270);

            head.transform.eulerAngles = new Vector3(0, yRotation, 0);

        }
        */


    }

    private void Update()
    {
        //head.transform.position = transform.position;
        head.transform.position = new Vector3(transform.position.x , transform.position.y + Rhead, transform.position.z);
    }


}
