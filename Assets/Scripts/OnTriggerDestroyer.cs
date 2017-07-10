using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroyer : MonoBehaviour {

    public string tagName;


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Name: " + other.gameObject.name + " Tag: " + other.gameObject.tag);
        if(other.gameObject.tag == tagName)
            Destroy(gameObject);

    }
}
