using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public float startDelay = 2f;
    public float repeatRate = 2f;
    private PlayerController PlayerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void SpawnObstacle()
    {
        Instantiate(prefab, transform.position, prefab.transform.rotation);
    }
    private void Update()
    {
        if(PlayerControllerScript.gameOver == true)
        {
            CancelInvoke("SpawnObstacle");
        }
    }
}
