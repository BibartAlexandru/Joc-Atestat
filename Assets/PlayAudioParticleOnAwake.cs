using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioParticleOnAwake : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject soundGameObject;

    private void Awake()
    {
        GameObject g = Instantiate(soundGameObject, transform.position, Quaternion.identity);
        g.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
