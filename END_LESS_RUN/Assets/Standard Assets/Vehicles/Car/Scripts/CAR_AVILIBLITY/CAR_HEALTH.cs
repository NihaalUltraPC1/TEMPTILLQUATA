using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;


namespace DreadEye.NihaalKnight
{
    public class CAR_HEALTH : MonoBehaviour
    {

        //REF OTHER SCRIPT................
        public CarController carController;
        public Presentage_Script presentage_Script;

        //REF GAME OBJECT......................
        public GameObject hit_effect1_car;
       

        //TO DISTORY THE GAMEOBJECT............
        public GameObject Car1;


        //HEALTH FOR THE CAR.........(VAR)....
        public float MaxHealth = 100f;
        public float CurHeath;


        



        public float CurSpeed;
        //CAR SPEED TO APPLY DAMAGE..........
        public float PA1;

        public Image HealthBar;
        public Text Hnum;

        //FOR SPEDOMETER_EXAMPLE.............
        public Text Hnum1;


        private void Start()
        {
            CurHeath = MaxHealth;
            UpdateCarHealthBar();
            ExampleSpeedoMeter();
        }


        private void ExampleSpeedoMeter()
        {
            float ratio = CurSpeed;
            Hnum1.text = (ratio).ToString("0") + " MPH";
        }


        private void UpdateCarHealthBar()
        {
            float ratio = CurHeath / MaxHealth;
            HealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            Hnum.text = (ratio * 100).ToString("0") + '%';

        }



        public void PercentCalculater1()
        {
            CurSpeed = carController.CurSpeed;
            //CAR SPEED TO APPLY DAMAGE..........(PA1)....
            PA1 = presentage_Script.PA1;
        }

        public void CarHealthDamage()
        {
           


          //HEALTH OF THE CAR UNITY!
            CurHeath -= PA1/2;




            if (CurHeath <= 0 && CurHeath <=0.9)
            {
                CurHeath = 0;
               if(CurHeath == 0 && CurHeath <= 0.9)
                {
                    Destroy(Car1);
                }
                else
                {
                    //
                }
            }
            else
            {

                //Debug.Log("you have health");
            }
            UpdateCarHealthBar();
        }


        private void Update()
        {
            //CarHealthDamage();
            PercentCalculater1();
            ExampleSpeedoMeter();
        }

    }
}
