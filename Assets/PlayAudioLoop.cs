using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioLoop : MonoBehaviour
{
    public AudioClip startAudio, loopingAudio;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = loopingAudio;
        audioSource.PlayOneShot(startAudio);
        audioSource.Play();
    }

}
