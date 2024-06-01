using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float timerStart;
    public float animationTime;

    private void Awake()
    {
        timerStart = Time.time;
    }

    private void Update()
    {
        if (Time.time >= timerStart + animationTime)
            Destroy(gameObject);
    }
}
