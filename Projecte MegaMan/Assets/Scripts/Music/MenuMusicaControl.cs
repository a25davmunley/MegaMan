using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicaControl : MonoBehaviour
{
    // Audio Source
    public AudioSource audioSource;

    // Sonido botón
    public AudioClip select;

    // Música menú
    public AudioClip menusmusic;

    void Start()
    {
        // Reproducir música del menú
        audioSource.clip = menusmusic;

        // Loop infinito
        audioSource.loop = true;

        // Reproducir
        audioSource.Play();
    }

    // Reproducir sonido click
    public void PlaySelect()
    {
        audioSource.PlayOneShot(select);
    }
}
