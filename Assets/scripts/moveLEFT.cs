using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLEFT : MonoBehaviour
{
    public float speed = 30f;
    public float leftBound;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //Si no game over:
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}