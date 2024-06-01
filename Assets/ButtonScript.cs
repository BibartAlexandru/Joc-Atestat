using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, UnityEngine.EventSystems.ISelectHandler
{
    private Button button;
    private AudioSource audioSource;
    public AudioClip onSelectClip;

    private void Awake()
    {
        button = GetComponent<Button>();
        audioSource = GameObject.Find("ButtonAudioSource").GetComponent<AudioSource>();
    }

    public void OnSelect(UnityEngine.EventSystems.BaseEventData eventData)
    {
        PlaySound(onSelectClip);
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
