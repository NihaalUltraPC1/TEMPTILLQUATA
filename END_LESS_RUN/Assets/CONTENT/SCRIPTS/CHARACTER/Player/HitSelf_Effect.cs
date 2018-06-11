using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSelf_Effect : MonoBehaviour {

    public ParticleSystem hitParticles;

   //public float lifeTime = 10f;

    private void Update()
    {
        //if(lifeTime > 0)
        // {
        //  lifeTime -= Time.deltaTime;
        //  if(lifeTime <= 0)
        //   {
        //      Destruction();
        //   }
        //}

        Destroy(GameObject.Find("Hit_02(Clone)"), 2);
    }
    

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        Instantiate(hitParticles, transform.position, transform.rotation);
       // Destroy(GameObject.Find("Hit_02(Clone)"), 2);
    }


    //void Destruction()
   // {
       // Destroy(hitParticles.gameObject);
   // }


}
