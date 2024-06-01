using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newPlayerData",menuName = "Data/Player Data/BaseData")] 
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Respawn State")]
    public GameObject respawnParticle;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;
    public float jumpHoldTime = 0.4f;

    [Header("InAirState")]
    public string fallSound;
    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;
    public float climbVelocity = 6f;
    public float wallJumpHoltTime = 0.25f;
    public float wallJumpXVelocity = 15f;
    public Sprite reversedSprite;
    public Sprite regularSprite;

    [Header("Attack")]
    public float attackCooldown = 0.3f;
    public LayerMask whatKnocksBackSelf;

    [Header("PogoJump")]
    public float pogoJumpForce = 10f;
    public float pogoJumpDuration = 0.2f;
    public Vector2 pogoJumpAngle = Vector2.up;

    [Header("Dash State")]
    public float dashCooldown = 0.3f;
    public float dashVelocity = 100;
    public float dashTime = 0.2f;
    public GameObject dashEffect;

}
