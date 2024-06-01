using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class D_Entity : ScriptableObject
{
    public float maxHealth = 3f;
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float closeRangeActionDistance = 1f;
    public float meleeAttackCooldown = 1f;
    public float playerCheckRadius = 10f;
    public float groundCheckRadius = 0.4f;
    public float knockBackForceResistance = 1f;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public GameObject[] hitEffects;
    public float invulnerabilityTimeAfterHit = 0.2f;
    public AudioClip walk, foundPlayer, chase, attack1, attack2;
    public AudioClip[] idle;
    public float knockBackForceWhenHit = 5f;
    public float knockBackDurationWhenHit = 0.1f;
    public float touchKnockBackForce = 5f;
    public float touchKnockBackDuration = 0.1f;
    public float touchDamage = 1f;
}
