using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Presentage_Script_AERO : MonoBehaviour
{
    public Engine_CC_Controll engine_CC_Controll;
    

    public float PA1;



    public void Start()
    {
       
      
    }


    public void Update()
    {
        //engine_CC_Controll.MaxEnginePower = MaxEnginePower;
        //engine_CC_Controll.EnginePower = Power;
        PAP1();

    }


    public void PAP1()
    {

        // PA1 = engine_CC_Controll.EnginePower;
        //PA1 = (PA1 / engine_CC_Controll.MaxEnginePower) *100;
        //PA1 = PA1 / 100;
        //engine_CC_Controll.Slider1.value = PA1;

        //engine_CC_Controll.EnginePower = engine_CC_Controll.Slider1.value;  // 0 -1024 bit   - 1bit

        
        engine_CC_Controll.EnginePower = engine_CC_Controll.Slider1.value;
        PA1 = (engine_CC_Controll.EnginePower/ engine_CC_Controll.MaxEnginePower)*100f;
        PA1 = PA1 / 100f;

    }
}
