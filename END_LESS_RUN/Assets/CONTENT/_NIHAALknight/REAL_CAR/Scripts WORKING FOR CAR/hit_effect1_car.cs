using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using DreadEye.NihaalKnight;

public class hit_effect1_car : MonoBehaviour {

    //Ref
    public ParticleSystem hitParticles;
    public AudioSource CarCrash;
    public CAR_HEALTH Carhealth;
    //public Camera_Shake CameraShake;

    //Getting audio sorce compounent..............
    AudioSource audioSource;


    //public float lifeTime = 10f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


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
        //Debug.Log("Hit");
        Instantiate(hitParticles, transform.position, transform.rotation);
        //StartCoroutine(CameraShake.Shake(0.15f, 0.4f));
        //Debug.Log("SHAKE");
//make camera to shake when the object is in hit.........
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
//GENERATES CAR CRASH SOUND....................
        audioSource.Play();

        Carhealth.CarHealthDamage();

        // Destroy(GameObject.Find("Hit_02(Clone)"), 2);
    }


    //void Destruction()
    // {
    // Destroy(hitParticles.gameObject);
    // }

}
