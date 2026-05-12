using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusicControl : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    private Rigidbody rb;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Música de fondo
        PlayBackgroundMusic();
    }

    void Update()
    {
        MovePlayer();
    }

    // MOVIMIENTO
    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        rb.velocity = movement * speed;
    }

    // MÚSICA DE FONDO
    void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}