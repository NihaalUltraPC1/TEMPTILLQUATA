using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeroLock : MonoBehaviour {

    public string Lock;
    public StangerCarLock StangerCarLock;
    public Ship_DisableEnableObject Ship_DisableEnableObject;

    public void Update()
    {
        if(Ship_DisableEnableObject.AeroIn == false)
        {
            if (StangerCarLock.Lock1 == "Locked")
            {
                Locked();
            }
            else if (StangerCarLock.Lock1 == "UnLocked")
            {
                UnLocked();
            }
        }
        

        if (Ship_DisableEnableObject.AeroIn == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Locked();
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                UnLocked();
            }
        }
        
    }


    public void Locked()
    {
        Lock = "Locked";
    }

    public void UnLocked()
    {
        Lock = "UnLocked";
    }

}
