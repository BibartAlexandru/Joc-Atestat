using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbdulBariScript : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Music()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }
}
