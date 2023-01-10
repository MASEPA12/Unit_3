using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLEFT : MonoBehaviour
{
    public float speed = 30;
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime *speed);
    }
}
