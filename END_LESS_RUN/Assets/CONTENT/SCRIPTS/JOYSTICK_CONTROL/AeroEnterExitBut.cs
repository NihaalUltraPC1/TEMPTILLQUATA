using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AeroEnterExitBut : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPointerDown;
    public bool isPointerExit;


    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        isPointerExit = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        isPointerExit = false;
    }

    private void Update()
    {
        
    }
}
