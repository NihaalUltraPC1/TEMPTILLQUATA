using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IS_GROUNDED : MonoBehaviour
{

    


    private void Start()
    {
        Debug.Log("Comp");
    }

    public void OntriggerEnter(Collider col)
    {
        Debug.Log("true");
        
        
            
    }

    public void OntriggerExit(Collision col)
    {
     
        Debug.Log("false");
    }
}
//if (col.gameObject.name == "Ground_Aero")
     
           
       