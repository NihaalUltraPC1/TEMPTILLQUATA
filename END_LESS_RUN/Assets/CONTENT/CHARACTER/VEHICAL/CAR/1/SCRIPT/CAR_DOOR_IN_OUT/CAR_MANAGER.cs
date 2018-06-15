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
        public GameObject Rot_Pad;
        public GameObject D_Pad;
        public GameObject Toggle;
        public GameObject PLAYER_AIBBILITY_BG;
        public GameObject CAR_APPLICANCE_1;
    //public GameObject PlayerBot;
        public GameObject CAMER_HOLDER_CAR_NK87_01;

        private GameObject player;

        //CHECK FOR TRUE OR FALSE.........
        private bool inVeh;

        void Start()
        {
            userCtrl.enabled = false;
            carCam.enabled = false;
            inVeh = false;
        //Player..........
            D_Pad.SetActive(true);
            Rot_Pad.SetActive(true);
            Toggle.SetActive(true);
            PLAYER_AIBBILITY_BG.SetActive(true);
        //Car...........
            CAR_APPLICANCE_1.SetActive(false);

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


                //PlayerBot.SetActive(false);// EXTRA.....

                player = playerObj;
                carCam.enabled = true;
                userCtrl.enabled = true;
                
                player.transform.parent = this.transform;

            //Player Switch to Car mode.....
                //BOT Tools......
                D_Pad.SetActive(false);
                Rot_Pad.SetActive(false);
                Toggle.SetActive(false);
                PLAYER_AIBBILITY_BG.SetActive(false);
                //Car Tools......
                CAMER_HOLDER_CAR_NK87_01.SetActive(true);
            //Car..............to PLAYER........
                CAR_APPLICANCE_1.SetActive(true);

                StartCoroutine(Time(true));
            }
            else
            {

                player.SetActive(true);
                carCam.enabled = false;
                userCtrl.enabled = false;
                player.transform.parent = null;
                
                player = null;


            //Switch Back to player........
                //BOT Tools......
                D_Pad.SetActive(true);
                Rot_Pad.SetActive(true);
                Toggle.SetActive(true);
                PLAYER_AIBBILITY_BG.SetActive(true);

                //Car Tools......

            //Car........To Player.........
                CAR_APPLICANCE_1.SetActive(false);
                CAMER_HOLDER_CAR_NK87_01.SetActive(false);


                StartCoroutine(Time(false));

            }
        }

        private IEnumerator Time(bool inVehicle)
        {
            yield return new WaitForSeconds(1);
            inVeh = inVehicle;

        }


    }
