using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;
using UnityEngine.UI;

public class Engine_CC_Controll : MonoBehaviour
{
    public AeroplaneController aeroplaneController;
    public Presentage_Script_AERO presentage_Script_AERO;
    
    
  


    public float EnginePower;
    public float MaxEnginePower;
    public float DEMO;


    //UI.........
    public Slider Slider1;
    //Spedometer_num
    public Text ASnum1;


    private void Start()
    {
        AeroSpeedoMeter();
        EnginePower = 0f;
        MaxEnginePower = 1024;
        Slider1.value = 0f;
    }

    private void AeroSpeedoMeter()
    {
        float ratio = aeroplaneController.AeroCurSpeed;
        ASnum1.text = (ratio).ToString("0") + " MPH";
    }




    private void FixedUpdate()
    {
        AeroSpeedoMeter();

        aeroplaneController.m_MaxEnginePower = EnginePower;

        if(EnginePower <= 0) // && CurHeath <= 0.9
        {
            EnginePower = 0;

                //if (EnginePower == 0) //&& CurHeath <= 0.9   
        }
        else if(EnginePower >= MaxEnginePower)
        {
            EnginePower = MaxEnginePower;

        }

        
        //presentage_Script_AERO.PA1 = Slider1.value;
      





    }

}
