using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeroLock : MonoBehaviour {

    public string Lock;
    public StangerCarLock StangerCarLock;
    public Ship_DisableEnableObject Ship_DisableEnableObject;
    public CarLockUnlockBut CarLocklockBut;
    public CarLockUnlockBut CarLockUnlockBut;

    //Disable Ref...........
    public GameObject CarLocked;
    public GameObject CarUnlocked;

    private void Start()
    {
        CarLocked.SetActive(false);
        CarUnlocked.SetActive(false);
    }


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
            if (Input.GetKeyDown(KeyCode.G) || CarLocklockBut.isPointerDownLocked == true)
            {
                Locked();
            }
            else if (Input.GetKeyDown(KeyCode.H) || CarLockUnlockBut.isPointerDownUnlocked == true)
            {
                UnLocked();
            }



            if (Lock == "Locked")
            {
                StartCoroutine("ifcarlockedthendelay");
              
            }
            else if (Lock == "UnLocked")
            {
                StartCoroutine("ifcarunlockedthendelay");
                
                
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



    IEnumerator ifcarlockedthendelay()
    {
        yield return new WaitForSeconds(0.2f);
        CarLocked.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        CarUnlocked.SetActive(true);
        
        
    }

    IEnumerator ifcarunlockedthendelay()
    {
        yield return new WaitForSeconds(0.2f);
        CarUnlocked.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        CarLocked.SetActive(true);
       
    }
}
