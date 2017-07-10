using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletScript : MonoBehaviour {

    public float speed;
    public float healthDamage = 25;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        
    }


    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Name: " + other.gameObject.name + " Tag: " + other.gameObject.tag);

        //Hit Enemy


        if (col.gameObject.tag == "Enemy")
        {
            //EnemyScript.Health = EnemyScript.Health - healthDamage;
            col.GetComponent<EnemyScript>().TakeDamage(healthDamage);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Destroy Bullet")
            Destroy(gameObject);

        //if ignore bullet, return
        if (col.gameObject.tag == "Ignore Bullet")
            return;
    }

}

