using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brake_Vs : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    //public GameObject Car;

    private bool isPointerDown;
    private float carSpeed1;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Car.GetComponent<Rigidbody>().velocity = Vector3.zero;
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }




    public float Car_Brake()
    {
        if (isPointerDown == true)
        {
            carSpeed1 = 2000;

        }
        else
        {
            carSpeed1 = 0;
        }
        return carSpeed1;
    }
}
