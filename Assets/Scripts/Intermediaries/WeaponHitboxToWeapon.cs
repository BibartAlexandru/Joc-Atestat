using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxToWeapon : MonoBehaviour
{
    private Weapon weapon;
    private IDamageable damageable;
    public GameObject groundHitParticles;
    public LayerMask groundLayer;
    public float rotationModifier = 0;
    private CapsuleCollider2D capsuleCollider;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        weapon = GetComponentInParent<Weapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        weapon.AddToDetected(collision);
    }
}
