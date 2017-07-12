using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;

public class NEnemyScript : NetworkBehaviour
{
    public const int maxHealth = 100;

    [SyncVar(hook = "UpdateHealthText")]
    public int health = maxHealth;

    public TextMesh healthText;
    public GameObject moreBlood;

    private bool isDying = false;

    private void Start()
    {
        UpdateHealthText(health);
    }

    public void TakeDamage(int amount)
    {
        //if (!isServer)
        //    return;
        
        if (health != 0)
        {
            health -= amount;
            UpdateHealthText(health);
        }

        if (health <= 0)
        {
            if (isDying == false)// called on the server, will be invoked on the clients
            {
                isDying = true;
                UpdateHealthText(health);
                FreakOut();
                Roper.instance.iDied();
            }
        }
        
    }
     
    public void UpdateHealthText(int health)
    {
        healthText.text = health.ToString();
    }

    public void FreakOut()
    {
        gameObject.transform.DOScale(2,2);
        gameObject.transform.DOJump(new Vector3(-1.2f, 2.2f, -14.6f), 3, 5, 2).OnComplete(DestroyOnNetwork);

        Debug.Log("freakout");
    }

    private void DestroyOnNetwork()
    {
        NetworkServer.Destroy(gameObject);
    }



}
