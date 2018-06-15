﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;


public class Ship_DisableEnableObject : MonoBehaviour {

    public AeroLock AeroLock;

    public GameObject Suttle_Camera;
    public AeroplaneUserControl AeroplaneUserControl;

    //Player
    //public GameObject player;
    public GameObject player1;
    public GameObject Player_BotUI;

    //UI DISABLE INTERDFACE.........
    public GameObject FlyControler;


    //BOOLEAN.....
    public bool inVeh;
    public bool AeroIn;


    private void Start()
    {
        AeroIn = false;
        Suttle_Camera.SetActive(false);
        AeroplaneUserControl.enabled = false;
        FlyControler.SetActive(false);

        //player.SetActive(true);
        player1 = GameObject.Find("PLAYER_BOT_MAIN");
        player1.SetActive(true);
        Player_BotUI.SetActive(true);

        //BOOLEAN.........
        inVeh = false;
}


    void Update()
    {
        
        //player1 = GameObject.Find("PLAYER_BOT_MAIN");
        /*


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inVeh == true)
            {
                VehicleControl(null);
            }
        }
        */
    }


    public void VehicleControl(GameObject playerObj)
    {
        if (inVeh == false)
        {
            //AeroLock.Locked();

            if (AeroLock.Lock == "Locked")
            {
                StartCoroutine("DelayOnEnterVechicallock");
            }
            else if(AeroLock.Lock == "UnLocked")
            {
                StartCoroutine("DelayOnEnterVechicalUnlock");
            }
            


            
        }
        else
        {
            
            //player.SetActive(true);
            //carCam.enabled = false;
            //userCtrl.enabled = false;

            //player1.transform.parent = null;

            //player1 = null;
            player1.SetActive(true);

            //Switch Back to player........
            //BOT Tools......
            Player_BotUI.SetActive(true);




            //Car........To Player.........
            Suttle_Camera.SetActive(false);
            AeroplaneUserControl.enabled = false;
            FlyControler.SetActive(false);

            AeroIn = false;

            StartCoroutine(Time(false));

        }
    }


    private IEnumerator Time(bool inVehicle)
    {
        yield return new WaitForSeconds(1);
        inVeh = inVehicle;

    }

    IEnumerator DelayOnEnterVechicalUnlock()
    {
        yield return new WaitForSeconds(2);
        //player1 = playerObj;
        //player1.transform.parent = playerObj.transform;
        //player.transform.parent = this.transform;


        //BOT Tools......
        Player_BotUI.SetActive(false);
        //player.SetActive(false);

        player1.SetActive(false);
        //Toggle.SetActive(false);

        //Player Switch to Car mode.....
        //Car Tools......
        Suttle_Camera.SetActive(true);
        AeroplaneUserControl.enabled = true;
        FlyControler.SetActive(true);


        AeroIn = true;

        StartCoroutine(Time(true));
    }


    IEnumerator DelayOnEnterVechicallock()
    {
        yield return new WaitForSeconds(8);
        //player1 = playerObj;
        //player1.transform.parent = playerObj.transform;
        //player.transform.parent = this.transform;


        //BOT Tools......
        Player_BotUI.SetActive(false);
        //player.SetActive(false);

        player1.SetActive(false);
        //Toggle.SetActive(false);

        //Player Switch to Car mode.....
        //Car Tools......
        Suttle_Camera.SetActive(true);
        AeroplaneUserControl.enabled = true;
        FlyControler.SetActive(true);


        AeroIn = true;

        StartCoroutine(Time(true));
    }

}
