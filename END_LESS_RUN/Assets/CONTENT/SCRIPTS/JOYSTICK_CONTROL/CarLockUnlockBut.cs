using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarLockUnlockBut : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPointerDownLocked;
    public bool isPointerDownUnlocked;


    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDownLocked = true;
        isPointerDownUnlocked = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDownLocked = false;
        isPointerDownUnlocked = false;
    }


}
