using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnParticleCollision : MonoBehaviour
{
    public GameObject deathSoundBox;
    public AudioClip[] audioClips;
    bool hasCollided = false;
    float lastColTime = 0f;   
    private void OnParticleCollision(GameObject other)
    {
        lastColTime = Time.time;
        if (!hasCollided)
        {
            GameObject g = Instantiate(deathSoundBox, transform.position, Quaternion.identity);
            g.GetComponent<AudioSource>().PlayOneShot(audioClips[Random.Range((int)0, (int)audioClips.Length)]);
            hasCollided = true;
        }
    }

    private void Update()
    {
        if (lastColTime + .2f < Time.time)  //daca nu a mai fost o coliziune cu cel putin 0.2 secunde inainte atunci inseamna ca data urm obiectu tre sa scoata sunet de collision
            hasCollided = false;
    }
}
