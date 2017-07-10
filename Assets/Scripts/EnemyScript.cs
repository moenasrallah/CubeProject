using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float health = 100;
    public TextMesh healthText;

    private void Start()
    {
        UpdateHealthText();
    }


    public void TakeDamage(float dmg)
    {
        health -= dmg;

        UpdateHealthText();
        if (health == 0)
        {
            //tell roper i died
            Destroy(gameObject);
        }
    }

    public void UpdateHealthText()
    {
        healthText.text = health.ToString();
    }
}
