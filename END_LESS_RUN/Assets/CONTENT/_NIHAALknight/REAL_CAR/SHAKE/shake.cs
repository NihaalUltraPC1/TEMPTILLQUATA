using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {

    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform camara;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

	// Use this for initialization
	void Start () {
        camara = Camera.main.transform;
        startPosition = camara.localPosition;
        initialDuration = duration; 
		
	}
	
	// Update is called once per frame
	void Update () {

        if(shouldShake)
        {
            if (duration > 0)
            {
                camara.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camara.localPosition = startPosition;
            }
        }
		
	}
}
