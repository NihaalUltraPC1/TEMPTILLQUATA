using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
    [RequireComponent(typeof(AeroplaneController))]
    public class AeroplaneUserControl : MonoBehaviour
    {
        //PUVBLIC.
        //REFRENCE SCRIPT.......................
        public AERO_STEERING_Wheel AERO_STEERING_Wheel;
        public AERO_STEERING_Wheel2 AERO_STEERING_Wheel_2;
        public Air_Brake air_Brake;
        //public IS_GROUNDED iS_GROUNDED;
        public Engine_CC_Controll Engine_CC_Controll;

        //PRIVATE.
        // reference to the aeroplane that we're controlling
        private AeroplaneController m_Aeroplane;

        //UI
        public Toggle Toggle1;
        

        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;
        //forward movement...........
        

        private float m_Throttle;
        private bool m_AirBrakes;
        private float m_Yaw;
        private float roll;

        //Bool
        


        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            
            
                m_Aeroplane = GetComponent<AeroplaneController>();
            
        
        }

        private void Start()
        {
            Toggle1.isOn = false;
           

            





        }


        private void FixedUpdate()
        {
            

            // Read input for the pitch, yaw, roll and throttle of the aeroplane.
            //float roll = CrossPlatformInputManager.GetAxis("Mouse X");
            //float pitch = CrossPlatformInputManager.GetAxis("Mouse Y");
            // m_AirBrakes = CrossPlatformInputManager.GetButton("Fire1");
            // m_Yaw = CrossPlatformInputManager.GetAxis("Horizontal");
            // m_Throttle = CrossPlatformInputManager.GetAxis("Vertical");

            //Toggle Between 2 Mode of Rot with Twist............
            if (Toggle1.isOn == false)
            {
                //Rot and Twist To-gether.............
                roll = AERO_STEERING_Wheel.ROT_Horizontal();
                
            }
            else if(Toggle1.isOn == true)
            {
                //Twist
                m_Yaw = AERO_STEERING_Wheel.ROT_Horizontal();

                //This Input  is not using in mobile but used in PC( its important on both Mobile as well as PC).............
                roll = AERO_STEERING_Wheel_2.Twist_Horizontal();//

            }


            //AirBrakeing System....
            if(air_Brake.isPointerDown == true)
            {
                m_AirBrakes = true;
            }
            else if(air_Brake.isPointerDown == false)
            {
                m_AirBrakes = false;
            }

            

            //m_Throttle = AERO_STEERING_Wheel_2.Vertical();
            //m_Throttle = Input.GetAxis("Vertical");

            //roll = Input.GetAxis("Mouse X");

            float pitch = Input.GetAxis("Mouse Y");
            //m_AirBrakes = Input.GetButton("Jump");


            //m_Yaw = Input.GetAxis("Vertical"); //Horizontal
            // m_Throttle = Input.GetAxis("Vertical");







            // auto throttle up, or down if braking.
            float throttle = m_AirBrakes ? -1 : 1;
#if MOBILE_INPUT
            AdjustInputForMobileControls(ref roll, ref pitch, ref throttle);
#endif
            // Pass the input to the aeroplane
            m_Aeroplane.Move(roll, pitch, m_Yaw, throttle, m_AirBrakes);
        }


        private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
        {
            // because mobile tilt is used for roll and pitch, we help out by
            // assuming that a centered level device means the user
            // wants to fly straight and level!

            // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
            // and the roll input is calculated to achieve that.
            // whereas on non-mobile, the input directly controls the roll of the aeroplane.

            float intendedRollAngle = roll * maxRollAngle * Mathf.Deg2Rad;
            float intendedPitchAngle = pitch * maxPitchAngle * Mathf.Deg2Rad;
            roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
            pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

            // similarly, the throttle axis input is considered to be the desired absolute value, not a relative change to current throttle.
            float intendedThrottle = throttle * 0.5f + 0.5f;
            throttle = Mathf.Clamp(intendedThrottle - m_Aeroplane.Throttle, -1, 1);
        }




       












        /*
#if MOBILE_INPUT
        AdjustInputForMobileControls(ref roll, ref pitch, ref m_Throttle);
#endif
        // Pass the input to the aeroplane
        m_Aeroplane.Move(roll, pitch, m_Yaw, m_Throttle, m_AirBrakes);
    }


    private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
    {
        // because mobile tilt is used for roll and pitch, we help out by
        // assuming that a centered level device means the user
        // wants to fly straight and level!

        // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
        // and the roll input is calculated to achieve that.
        // whereas on non-mobile, the input directly controls the roll of the aeroplane.

        float intendedRollAngle = roll * maxRollAngle * Mathf.Deg2Rad;
        float intendedPitchAngle = pitch * maxPitchAngle * Mathf.Deg2Rad;
        roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
        pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

    }


    */

    }
}

	

