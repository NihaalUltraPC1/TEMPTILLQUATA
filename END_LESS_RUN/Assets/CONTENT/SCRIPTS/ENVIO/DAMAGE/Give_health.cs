using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Give_health : MonoBehaviour {

    public bool isHealing;
    public float Health;

    private void OnTriggerStay(Collider col)
    //private void OnParticalCollision(Collider col)

    {

        if (col.tag == "BODY")
            col.SendMessage((isHealing) ? "HealDamage" : "HealthDamage", Time.deltaTime * Health);

    }
}
