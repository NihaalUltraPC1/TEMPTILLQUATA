using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test_move : MonoBehaviour {

    //Taging VSyncAndriod
    public VirtualJoystick joystick;
    //public GameObject total;

    //Player
    public GameObject Body;
    public GameObject camera;
    public GameObject head;

    //INPUT
    public float jumpHeight = 50;
   // public float rotateSpeed = 175;
    public float RotateSpeed = 30f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;

    public float Rhead = 1f;

    public float speed;
    private Rigidbody rb;

    //PLAYER HEALTH VARIABLE
    public Image HealthBar;
    public Text Hnum;

    private float hitPoint = 150;
    private float maxHitpoint = 150;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        UpdateHealthbar();
        
    }

    private void UpdateHealthbar()
    {
        float ratio = hitPoint / maxHitpoint;
        HealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        Hnum.text = (ratio * 100).ToString("0") + '%';
        
        

    }

    private void TakeDamage(float Damage)
    {
        hitPoint -= Damage;
        if (hitPoint < 0)
        {
            hitPoint = 0;
            Debug.Log("dead!");
        }
        UpdateHealthbar();
    }

    private void HealDamage (float Heal)
    {
        hitPoint += Heal;
        if (hitPoint > maxHitpoint)
            hitPoint = maxHitpoint;
        Debug.Log("HEALING!");
    }





     void FixedUpdate()
     {
         //float h = Input.GetAxis("Horizontal");
         //float v = Input.GetAxis("Vertical");

        float h = joystick.Horizontal();
        float v = joystick.Vertical();

         GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * v);
         GetComponent<Rigidbody>().AddForce(Vector3.right * speed * h);

        


         if (h == 0 && v == 0)
         {
              GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
         }
        //Vector3 movement = new Vector3(h, 0.0f, v);

        //rb.AddForce(movement * speed);


    } 

    private void Update()
     {
       //head.transform.position = transform.position;
         head.transform.position = new Vector3(transform.position.x, transform.position.y + Rhead, transform.position.z);

    // if (Input.GetKeyDown("space"))
    //     transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
    /*
            //Rotates Player Right
            if (Input.GetKey(KeyCode.Q))
                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

            if (Input.GetKey(KeyCode.E))
                transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
     */


    //ROTATE CAMERA
      if (Input.GetKey(KeyCode.Q))
          camera.transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
      else if (Input.GetKey(KeyCode.E))  
          camera.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
       

    // if (Input.GetKey(KeyCode.E))
    //     Body.transform.Rotate(0, Time.deltaTime * clockwise, 0);
    // else if (Input.GetKey(KeyCode.Q))
    //     Body.transform.Rotate(0, Time.deltaTime * counterClockwise, 0);





   



    //ROTATE HEAD
      if (Input.GetKey(KeyCode.Q))
          head.transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
      else if (Input.GetKey(KeyCode.E))
          head.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);


      }


    /*
     void Update()
     {
         if (Input.GetKey(KeyCode.W))
         {
            //GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
         else if (Input.GetKey(KeyCode.S))
         {
             transform.position -= transform.forward * Time.deltaTime * speed;
         }
         else if (Input.GetKey(KeyCode.A))
         {
             transform.position -= transform.right * Time.deltaTime * speed;
         }
         else if (Input.GetKey(KeyCode.D))
         {
             transform.position += transform.right * Time.deltaTime * speed;
         }

         if (Input.GetKey(KeyCode.E))
         {
             transform.Rotate(0, Time.deltaTime * clockwise, 0);
         }
         else if (Input.GetKey(KeyCode.Q))
         {
             transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
         }
     }
     
    */

}
