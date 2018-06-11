using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public Transform Player;
    static Animator anim;
    public ParticleSystem KillerSmoke;
    public Transform KillerSpawn;




    private void Start()
    {
       
        anim = GetComponent<Animator>();
       // StartCoroutine(Black());
    }





    private void Update()
    {
        //if (Vector3.Distance(Player.position, this.transform.position) < 10)
        Vector3 direction = Player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if(Vector3.Distance(Player.position, this.transform.position) < 10 && angle < 30)
        {
           // Vector3 direction = Player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


            anim.SetBool("Idle", false);
            if(direction.magnitude > 5)
            {

                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("Walk", true);
                anim.SetBool("Att", false);
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Att", true);

                if(direction.magnitude < 5)
                {
                   
                    Instantiate(KillerSmoke, KillerSpawn.position, KillerSpawn.rotation);
                    

                   // Destroy(GameObject.Find("KILLER_SMOKE(Clone)"), 2);
               
                }
                // Instantiate(KillerSmoke, transform.position, transform.rotation);
                //StartCoroutine(Damage());


                // Destroy(GameObject.Find("KILLER_SMOKE(Clone)"), 1);
                
            }




        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Att", false);
           // Destroy(GameObject.Find("KILLER_SMOKE(Clone)"), 2);
            
        }



    }


  




}
