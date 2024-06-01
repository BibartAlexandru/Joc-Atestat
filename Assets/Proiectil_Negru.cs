using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiectil_Negru : Entity
{

    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private GameObject deathSoundObject;
    [SerializeField] private AudioClip deathAudioClip;
    private Unity_Events events;
    public bool hasCollided;
    public override void Update()
    {
        if (hasCollided)
        {
            events.bigCameraShake.Invoke();
            GameObject g = Instantiate(deathSoundObject, transform.position, Quaternion.identity);
            g.GetComponent<AudioSource>().PlayOneShot(deathAudioClip);
        }
        if (lifeTime <= 0 || hasCollided)
        {
            GameObject.Instantiate(deathParticle, transform.position, Quaternion.identity);
            GameObject g = Instantiate(deathSoundObject, transform.position, Quaternion.identity);
            g.GetComponent<AudioSource>().PlayOneShot(deathAudioClip);
            Destroy();
        }
        lifeTime -= Time.deltaTime;
    }

    public override void FixedUpdate()
    {
    }

    public override void Awake()
    {
        base.Awake();
        events = GameObject.Find("Events").GetComponent<Unity_Events>();
        hasCollided = false;
    }

    public override void SwitchToDeadState()
    {
        base.SwitchToDeadState();
        hasCollided = true;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
