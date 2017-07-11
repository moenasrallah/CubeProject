using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;

public class EnemyScript : NetworkBehaviour
{

    public float health = 100;
    public TextMesh healthText;
    public GameObject moreBlood;
    private bool isDying = false;
    private void Start()
    {
        UpdateHealthText();
    }


    public void TakeDamage(float dmg)
    {
        if (health != 0)
        {
            health -= dmg;
            UpdateHealthText();
        }

        if (health == 0)
        {
            if (!isDying)
            {
                isDying = true;
                FreakOut();
                Roper.instance.iDied();
             
                Destroy(gameObject, 1);
            }
        }
    }

    public void UpdateHealthText()
    {
        healthText.text = health.ToString();
    }

    public void FreakOut()
    {
        gameObject.transform.DOScale(2,2);
        gameObject.transform.DOFlip();
        gameObject.transform.DOJump(new Vector3(-1.2f, 2.2f, -14.6f), 3, 5, 2);
        Debug.Log("freakout");
    }
    
}
