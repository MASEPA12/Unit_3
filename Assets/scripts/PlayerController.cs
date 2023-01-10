using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float JumpForce = 10;
    private bool isOnTheGround = true;
    public bool gameOver;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround == true)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
        else if(otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnTheGround = true;
            }
    }
}
