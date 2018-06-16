using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




    public class test_move_real : MonoBehaviour
    {

        //REFRENCE SCRIPT.............
        private test_move_real Ball;

        //
        [SerializeField] private float V_MovePower = 500;
        [SerializeField] private bool V_UseTorque = true;
        [SerializeField] private float V_MaxAngularVelocity = 25;
        [SerializeField] private float V_JumpPower = 2;


        //GROUND
        private const float V_GroundRayLength = 1f;


        //Taging VSyncAndriod
        public VirtualJoystick joystick;
        //public GameObject total;

        //Camera Facing Movement - Camera Detection
        private Transform cam;
        private Vector3 camForward;

        //Player
        private bool Jump;
        private Vector3 Player;
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

        private float CurrentHealth = 150;
        private float MaxHealth = 150;
        //public float Heal = 5;
        public float Health;
        public bool isHealing;
        // public float SurHealth;


        //Player Fuel Varibles
        public Image FuelBar;
        // public Text Fnum;
        public float CurFuel = 150;
        private float MaxFuel = 150;
        private float Empfuel = 10;
        public bool isEmpFueling;





        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().maxAngularVelocity = V_MaxAngularVelocity;
            UpdateHealthbar();
            UpdateFuelBar();


        }

        private void UpdateHealthbar()
        {
            float ratio = CurrentHealth / MaxHealth;
            HealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            Hnum.text = (ratio * 100).ToString("0") + '%';
            // HealDamage();


        }

        private void TakeDamage(float Damage)
        {
            //isHealing = false;
            CurrentHealth -= Damage;
            // SurHealth = CurrentHealth - Damage;


            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
                Debug.Log("dead!");
                Destroy(gameObject);
            }
            UpdateHealthbar();

            //HealDamage();

        }

        private void HealFeed(float Feed)
        {
            //  isHealing = true;
            CurrentHealth += Feed;
            // CurrentHealth = SurHealth + Feed;

            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
                isHealing = false;
            }
            UpdateHealthbar();
        }

        private void HealDamage(float Heal)
        {
            CurrentHealth += Heal;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;

            UpdateHealthbar();

            //CurrentHealth += Heal;
            //  if(CurrentHealth > MaxHealth)
            //  {
            //      Debug.Log("health");
            //  }
            //  else if(CurrentHealth == MaxHealth)
            //  {
            //     Debug.Log("not");
            // }


        }


        private void UpdateFuelBar()
        {
            float ratio = CurFuel / MaxFuel;
            FuelBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            // Hnum.text = (ratio * 100).ToString("0") + '%';



        }

        //Fuel
        public void EmptyFuel(float Empfuel)
        {

            CurFuel -= Empfuel;
            if (CurFuel < 0)
            {
                CurFuel = 0;
                Debug.Log("fuel is over");
                V_MovePower = 30;
            }

            UpdateFuelBar();

        }

        //Camera Facing Movement - Camera Detection
        private void Awake()
        {
            Ball = GetComponent<test_move_real>();

            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning("Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            }

        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            if (V_UseTorque)
            {

                rb.AddForce(new Vector3(moveDirection.z, 0, -moveDirection.x) * V_MovePower);

            }
            else
            {

                rb.AddForce(moveDirection * V_MovePower);
            }


            if (Physics.Raycast(transform.position, -Vector3.up, V_GroundRayLength) && jump)
            {

                rb.AddForce(Vector3.up * V_JumpPower, ForceMode.Impulse);
            }
        }






        private void Update()
        {

            if (isHealing == true)
            {

                SendMessage((isHealing) ? "HealFeed" : "HealthDamage", Time.deltaTime * Health);
            }

            //SendMessage((isHealing) ? "HealFeed" : "HealthDamage", Time.deltaTime * Health);


            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");

            float h = joystick.Horizontal();
            float v = joystick.Vertical();
            Jump = Input.GetButton("Jump");

            //****  GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * v);
            //**** GetComponent<Rigidbody>().AddForce(Vector3.right * speed * h);

            if (cam != null)
            {
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                Player = (speed * v * camForward + speed * h * cam.right).normalized;


            }
            else
            {
                Player = (speed * v * Vector3.forward + speed * h * Vector3.right).normalized;

            }

            if (h != 0 || v != 0)
            {
                isEmpFueling = true;

                if (isEmpFueling == true)
                {

                    SendMessage((isEmpFueling) ? "EmptyFuel" : "FuelDamage", Time.deltaTime * Empfuel);


                }

            }


            //**** To Stop a object form Moving if no input is pressed........
            if (h == 0 && v == 0)

            {

                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                isEmpFueling = false;


            }
            //Vector3 movement = new Vector3(h, 0.0f, v);

            //rb.AddForce(movement * speed);

            head.transform.position = new Vector3(transform.position.x, transform.position.y + Rhead, transform.position.z);


        }


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            Ball.Move(Player, Jump);
            Jump = false;
        }



 


        /* private  Update()
         {
             //head.transform.position = transform.position;
             //****head.transform.position = new Vector3(transform.position.x, transform.position.y + Rhead, transform.position.z);

             // if (Input.GetKeyDown("space"))
             //     transform.Translate(Vector3.up * Time.deltaTime * jumpHeight);
             /*
                     //Rotates Player Right
                     if (Input.GetKey(KeyCode.Q))
                         transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

                     if (Input.GetKey(KeyCode.E))
                         transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
              */

        /*
            //ROTATE CAMERA
            if (Input.GetKey(KeyCode.Q))
                camera.transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
            else if (Input.GetKey(KeyCode.E))
                camera.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);


            // if (Input.GetKey(KeyCode.E))
            //     Body.transform.Rotate(0, Time.deltaTime * clockwise, 0);
            // else if (Input.GetKey(KeyCode.Q))
            //     Body.transform.Rotate(0, Time.deltaTime * counterClockwise, 0);

        /*









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


