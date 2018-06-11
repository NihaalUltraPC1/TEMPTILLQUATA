using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{

    private bool inTrigger;
    private GameObject player;
    public CAR_MANAGER carlock;


    void Update()
    {
        if(inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                carlock.VehicleControl(player);
                inTrigger = false;

            }
        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        inTrigger = true;
        player = col.gameObject;

        
    }

    private void OnTriggerExit()
    {
        inTrigger = false;
        player = null;
        
    }
   

}
