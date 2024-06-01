using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Collision : MonoBehaviour
{
    [SerializeField] private string targetTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
            GetComponentInParent<Proiectil_Negru>().hasCollided = true;
    }
}
