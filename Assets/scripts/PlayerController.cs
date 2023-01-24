using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;

    public bool gameOver;

    public float gravityMultiplier = 1.5f;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private Rigidbody _rigidbody;
    private bool isOnTheGround = true;

    private Animator _animator;

    public AudioClip[] crashSounds;
    public AudioClip[] jumpSounds;
    private AudioSource AUDIOSOURCE;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
        AUDIOSOURCE = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherCollider.gameObject);
            GameOver();
        }
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", Random.Range(1, 3));
        explosionParticle.Play();
        dirtParticle.Stop();
    }

    private void Jump()
    {
        isOnTheGround = false; // Dejo de tocar el suelo
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // Llamamos al trigger para que se dé la transición de la animación de correr a salto
        _animator.SetTrigger("Jump_trig");
        dirtParticle.Stop();


    }

    private void ChooseRandomSFX(AudioClip[] sounds)
    {
        int randomIndx = Random.Range(0, sounds.Length);
        AUDIOSOURCE.PlayOneShot(sounds[randomIndx], 1);
    }
}