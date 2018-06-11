using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;




    public class CAR_MANAGER : MonoBehaviour
    {
        //REF................
        public Camera carCam;
        public CarUserControl userCtrl;
        //public test_move_real PlayerMovement;

        private GameObject player;

        //CHECK FOR TRUE OR FALSE.........
        private bool inVeh;

        void Start()
        {
            userCtrl.enabled = false;
            carCam.enabled = false;
            inVeh = false;


        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inVeh == true)
                {
                    VehicleControl(null);
                }
            }

        }

        public void VehicleControl(GameObject playerObj)
        {
            if (inVeh == false)
            {
                player = playerObj;
                carCam.enabled = true;
                userCtrl.enabled = true;
                player.transform.parent = this.transform;
                StartCoroutine(Time(true));
            }
            else
            {
                player.SetActive(true);
                carCam.enabled = false;
                userCtrl.enabled = false;
                player.transform.parent = null;
                player = null;
                StartCoroutine(Time(false));

            }
        }

        private IEnumerator Time(bool inVehicle)
        {
            yield return new WaitForSeconds(1);
            inVeh = inVehicle;

        }


    }
