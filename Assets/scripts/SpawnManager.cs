using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public float startDelay = 2f;
    public float repeatRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);   
    }

    private void SpawnObstacle()
    {
        Instantiate(prefab, transform.position, prefab.transform.rotation);
    }

}
