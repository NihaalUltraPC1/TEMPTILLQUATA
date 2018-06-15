using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suttle_trigger : MonoBehaviour {

    public bool inTrigger;
    public GameObject player;
    public Ship_DisableEnableObject carlock;
    public AudioSource LaserSound;


    public int CarExit;

    [Header("....Enter Aero Lock....")]
    public AeroLock AeroLock;

    [Header("....Enter Effect....")]
    public LineRenderer LineRenderer;


    private void Start()
    {
        CarExit = 0;
        inTrigger = false;
        LineRenderer.enabled = false;
    }

    void Update()
    {

     

        if (inTrigger == true)
        {
            
            if (Input.GetKeyDown(KeyCode.F) && CarExit == 0)
            {
                
                CarExit = 1;
                carlock.VehicleControl(player);
                //inTrigger = false;
                LaserSound.Play();
                LineRenderer.enabled = true;


                if(AeroLock.Lock == "Locked")
                {
                    StartCoroutine("DelayOnEnterVechicallock");
                }
                else if(AeroLock.Lock == "UnLocked")
                {
                    StartCoroutine("DelayOnEnterVechicalUnlock");
                }


                



            }
            else if (Input.GetKeyDown(KeyCode.F) && CarExit == 1)
            {

                CarExit = 0;
                carlock.VehicleControl(player);
                //inTrigger = false;


            }
        }
       
        







    }



    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("In");
        inTrigger = true;
        player = col.gameObject;


    }

    private void OnTriggerExit()
    {
        //Debug.Log("OUT");
        inTrigger = false;
        player = null;

    }



    IEnumerator DelayOnEnterVechicalUnlock()
    {
        yield return new WaitForSeconds(2);
        LineRenderer.enabled = false;
        LaserSound.Stop();
    }

    IEnumerator DelayOnEnterVechicallock()
    {
        yield return new WaitForSeconds(8);
        LineRenderer.enabled = false;
        LaserSound.Stop();
    }
}
