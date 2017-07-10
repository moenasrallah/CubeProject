using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    Vector3 startScale;
    CharacterController controller;
    public float speed;
    Vector3 moveDirection;
    public GameObject playerEffect;

    private void Start()
    {
        startScale = gameObject.transform.localScale;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
        FireBullet();
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

    void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject holder = Instantiate(bullet, transform.position, transform.rotation);
            playerEffect.transform.DOShakeScale(0.5f);
            playerEffect.transform.DOScale(startScale, 0.2f).SetDelay(0.5f);
        }
    }

}