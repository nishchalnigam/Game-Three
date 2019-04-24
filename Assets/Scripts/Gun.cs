using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public AudioSource gunShot;
    public AudioSource ricochet;

    public Camera fps;

    void Start()
    {
        
        ricochet = GameObject.Find("Ricochet").GetComponent<AudioSource>();
        gunShot = GameObject.Find("Gunshot").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}


    void Shoot()
    {
        gunShot.Play();
        RaycastHit hit;
        if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            if(hit.transform.name.Equals("Pigman") == false)
            {
                ricochet.Play();
            }


            Target target = hit.transform.GetComponent<Target>();
            Target2 target2 = hit.transform.GetComponent<Target2>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (target2 != null)
            {
                target2.TakeDamage(damage);
            }
        }
    }
}
