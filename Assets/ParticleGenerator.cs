using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject effect;
    public float generationCooldown;
    private float lastTimeGenerated = 0;


    private void Update()
    {
        if(Time.time > lastTimeGenerated + generationCooldown)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            lastTimeGenerated = Time.time;
        }
    }
}
