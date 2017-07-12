using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBullet : MonoBehaviour {

    public float dmg;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DoGun(25, 10, 200);
        }
	}

    void DoGun(float damage,float spread,float distance)
    {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.tag == "Enemy")
                {
                    //EnemyScript.Health = EnemyScript.Health - healthDamage;
                   // hit.collider.GetComponent<EnemyScript>().TakeDamage(damage);
                    Debug.Log("Distance " + hit.distance);
                    Debug.Log("Point " + hit.point);
                Debug.DrawLine(transform.position, hit.point);
                }
                else
                {
                    Debug.DrawLine(transform.position, hit.point,Color.green);
                }
            }
    }
}
