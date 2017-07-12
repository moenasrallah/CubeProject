using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Networking;

public class NPlayerController: NetworkBehaviour
{
    public GameObject bulletPrefab;
    Vector3 startScale;
    CharacterController controller;
    public float speed;
    Vector3 moveDirection;
    public GameObject playerEffect;

    private void Start()
    {
        startScale = gameObject.transform.localScale;
        controller = GetComponent<CharacterController>();
        transform.position = new Vector3(0,2.11f, -6.95f);
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFireBullet();
        }

    }

    void MovePlayer()
    {
        moveDirection = Vector3.zero;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection.x = x;
        moveDirection.y = 0;
        moveDirection.z = z;

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    [Command]
    void CmdFireBullet()
    {
            GameObject bullet = (GameObject)Instantiate(
                        bulletPrefab,
                        transform.position,
                        Quaternion.identity);
       
            NetworkServer.Spawn(bullet);

            playerEffect.transform.DOShakeScale(0.5f);
            playerEffect.transform.DOScale(startScale, 0.2f).SetDelay(0.5f);
        
        
    }

}