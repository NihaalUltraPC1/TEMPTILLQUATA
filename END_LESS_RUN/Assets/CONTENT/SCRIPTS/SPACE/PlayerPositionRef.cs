using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionRef : MonoBehaviour {

    public Ship_DisableEnableObject Ship_DisableEnableObject;
    public GameObject Player2;

    // Use this for initialization
    void Start () {
        Player2 = GameObject.Find("PLAYER_BOT_MAIN");

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = transform.position;
        float v1 = transform.position.x;
        //Debug.Log(v1);
        if (Ship_DisableEnableObject.inVeh == false)
        {
            //Ship_DisableEnableObject.player.transform.parent = this.transform;
            Player2.transform.parent = this.transform;
            //Player1.transform.parent = this.transform;
            // Player1.transform.parent = v1;
        }


    }
}
