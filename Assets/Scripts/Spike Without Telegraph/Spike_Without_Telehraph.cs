using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Without_Telehraph : Spike
{
    protected override void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Rise()
    {
        animator.Play("Spike Rise");
    }
}
