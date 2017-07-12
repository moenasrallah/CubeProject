using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;

public class NBulletScript : NetworkBehaviour
{

    public float speed;
    public int healthDamage = 25;
    public GameObject bloodParticles;
    GameObject holder;

    Roper Roper;

    void Start ()
    {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);   
    }

    [ClientCallback]
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //EnemyScript.Health = EnemyScript.Health - healthDamage;
            col.GetComponent<NEnemyScript>().TakeDamage(healthDamage); 
            BulletExplode(bloodParticles);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Destroy Bullet")
            Destroy(gameObject);

        //if ignore bullet, return
        if (col.gameObject.tag == "Ignore Bullet")
            return;
        
    } 

    void BulletExplode(GameObject effect)
    {
        holder = Instantiate(effect, transform.position, transform.rotation);
        Destroy(holder, 1);
    }
}

