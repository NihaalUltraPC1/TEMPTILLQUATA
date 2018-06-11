using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;



namespace DreadEye.NihaalKnight
{
    public class CAR_FUEL : MonoBehaviour
    {
        //REF OTHER SCRIPT..............
        public CarController carController;
        public Presentage_Script presentage_Script;
        public CarUserControl CarUserControl;

        //CAR FUEL.............
        public float CurFuel;
        public float Maxfuel;

        //STORING VAR.............
        public float PA2;
        public float CurSpeed;

        //UI.................
        public Image FuelBar;
        public Text Hnum;


        private void Start()
        {
            Maxfuel = 10000;
            CurFuel = Maxfuel;
            UpdateCarFuelBar();
        }



        private void UpdateCarFuelBar()
        {
            float ratio = CurFuel / Maxfuel;
            FuelBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
           // Hnum.text = (ratio * 100).ToString("0") + '%';
            Hnum.text = (ratio*26).ToString("0.0") + 'L';

        }



        public void PercentCalculater2()
        {
            CurSpeed = carController.CurSpeed;
            //CAR SPEED TO APPLY DAMAGE..........(PA1)....
            PA2 = presentage_Script.PA2;


        }

        public void FuelConsumedSystem()
        {

           // CurFuel -= PA2;


            if (CurFuel <= 0 && CurFuel <= 0.9)
            {
                CurFuel = 0;
                carController.m_FullTorqueOverAllWheels = 0;
                carController.m_ReverseTorque = 0;

                //if (CurFuel == 0 && CurFuel <= 0.9)
                // {
                //Destroy(Car1);
                // }
            }

                UpdateCarFuelBar();
        }
      

        private void FixedUpdate()
        {
            PercentCalculater2();
            /*
            if(PA2 > 0)
            {
                FuelConsumedSystem();
            }
            else if(PA2 <= 0)
            {
                //do nothing..........
            }  */



            if (CarUserControl.Accelerated == true)
            {

                //GEAR - 1
                if (PA2 > 0.3 && PA2 <= 5)
                {
                    CurFuel -= 3f;
                    FuelConsumedSystem();
                   // Debug.Log(CurFuel);

                }
                //GEAR - 2
                else if (PA2 >= 6 && PA2 <= 25)
                {
                    CurFuel -= 2f;
                    FuelConsumedSystem();
                   // Debug.Log(CurFuel);

                }
                //GEAR - 3
                else if (PA2 >= 26 && PA2 <= 50)
                {
                    CurFuel -= 0.5f;
                    FuelConsumedSystem();
                    //Debug.Log(CurFuel);

                }
                //GEAR - 4
                else if (PA2 >= 51 && PA2 <= 75)
                {
                    CurFuel -= 0.2f;
                    FuelConsumedSystem();
                   // Debug.Log(CurFuel);

                }
                //GEAR - 5 -INF
                else if (PA2 >= 76 && PA2 <= 100)
                {
                    CurFuel -= 0.1f;
                    FuelConsumedSystem();
                    //Debug.Log(CurFuel);

                }

            }
                
         


        }

    }
}
