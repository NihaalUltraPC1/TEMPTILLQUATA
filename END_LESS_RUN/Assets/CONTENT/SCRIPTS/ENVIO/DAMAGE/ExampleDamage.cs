using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDamage : MonoBehaviour {

    public bool isDamaging;
    public float Damage;
 //   public GameObject PlayerBody;
    public test_move_real test_move_real;

    private void OnTriggerStay(Collider col)
    //private void OnParticalCollision(Collider col)
    
    {
       
        if (col.tag == "BODY")
        test_move_real.isHealing = false;
        isDamaging = true;
        col.SendMessage((isDamaging) ? "TakeDamage" : "HealthDamage", Time.deltaTime * Damage);

        

    }


    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "BODY")
        { 
            test_move_real.isHealing = true;
            isDamaging = false;
        }

    }








}
