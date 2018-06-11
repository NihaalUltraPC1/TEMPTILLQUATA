using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]

    public class CarUserControl : MonoBehaviour
    {

        //Ref
        //Taging VSyncAndriod
        //public JoystickMove joystick1;
        public Streeing_Wheel joystick1;
        public Accleration ForceForwardjM;
        public Back_Accleration ForceBackjM;
        public Brake_Vs Brake_vs;


        private CarController m_Car; // the car controller we want to use

        //BOOLEAN
        //For to check the call is Accelerated or not..............
        public bool Accelerated;
        

     


        private void Start()
        {
            Accelerated = false;
           
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // float v = CrossPlatformInputManager.GetAxis("Vertical");

            //float h = Input.GetAxis("Horizontal");


            
           
            
               //float v = Input.GetAxis("Vertical");
            

            
                


               float h = joystick1.Horizontal();
            
           
            //float v = joystick1.Vertical();

             float v = ForceForwardjM.AcclerateCar();
             float e = ForceBackjM.BackAcclerateCar();
            
             float f = Brake_vs.Car_Brake();

            //CHECK FOR THE CAR DRIVER IS PRESSING ACCLERATOR OR NOT.....................

            if (v > 0 || e < 0)
            {
                Accelerated = true;
            }
            else
            {
                Accelerated = false;
            }
            //float handbrake = Input.GetAxis("Jump");


#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            //m_Car.Move(h, v, v, handbrake);
            m_Car.Move(h, v, e, handbrake);
#else
            // m_Car.Move(h, v, v, 0f);
            m_Car.Move(h, v, e, f);
#endif
        }
    }
}
