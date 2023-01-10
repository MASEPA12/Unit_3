using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLEFT : MonoBehaviour
{
    private PlayerController PlayerControllerScript;
    public float speed = 30;


    private void Start()
    {
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if(PlayerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
