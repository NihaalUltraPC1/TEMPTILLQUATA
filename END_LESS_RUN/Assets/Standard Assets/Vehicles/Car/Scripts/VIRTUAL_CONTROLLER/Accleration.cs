using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Accleration : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    bool isPointerDown = false;
    float carSpeed = 0;
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    

     public float AcclerateCar()
     {
         if(isPointerDown == true)
         {
             carSpeed += 0.1f;

         }
         else
         {
             carSpeed = 0;
         }
         return carSpeed;
     }

 
}
