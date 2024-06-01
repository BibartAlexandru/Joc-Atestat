using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParent : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void BigCameraShake()
    {
        animator.Play("Shake");
    }

    public void SmallCameraShake()
    {
        animator.Play("EasyShake");
    }
}
