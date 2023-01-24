using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }

    private void SpawnObstacle()
    {
        int RandomIndx = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[RandomIndx], transform.position,obstaclePrefab[RandomIndx].transform.rotation);
    }
}