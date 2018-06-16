
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Air_Brake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPointerDown;
    


    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    
    

}
