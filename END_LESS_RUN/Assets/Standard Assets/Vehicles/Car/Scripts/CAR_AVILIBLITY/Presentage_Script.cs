using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreadEye.NihaalKnight;




public class Presentage_Script : MonoBehaviour
{ 

    public CAR_HEALTH CAR_HEALTH;


    //CAR SPEED TO APPLY DAMAGE..........
    public float PA1;
    //CAR SPEED TO APPLY FUEL_SYSTEM..........
    public float PA2;



    public void Update()
    {
        PC1();
        PC2();
    }


    public void PC1()
    {
        PA1 = CAR_HEALTH.CurSpeed;
        
        //MAKE THE GIVEN CAR SPEED INTO PERCENTAGE(%)......
        PA1 = (PA1 / 420)*100;

    }

    public void PC2()
    {
        PA2 = CAR_HEALTH.CurSpeed;

        PA2 = (PA2 / 420) * 100;


    }
    





}
    
