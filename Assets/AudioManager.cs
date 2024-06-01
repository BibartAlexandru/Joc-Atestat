using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
        if(sound != null && audioSource != null && Resources.Load<AudioClip>(sound) != null)
        audioSource.PlayOneShot(Resources.Load<AudioClip>(sound));
    }
}
