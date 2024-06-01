using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheck { get => groundCheck; private set => groundCheck = value; }
    public Transform WallCheck { get => wallCheck; private set => wallCheck = value; }
    public float WallCheckDistance { get => wallCheckDistance; private set => wallCheckDistance = value; }
    public float GroundCheckRadius { get => groundCheckRadius; private set => groundCheckRadius = value; }
    public LayerMask WhatIsGround { get => whatIsGround; private set => whatIsGround = value; }
    public float WallCheckDistance1 { get => wallCheckDistance; private set => wallCheckDistance = value; }
    public float LedgeCheckDistance { get => ledgeCheckDistance; set => ledgeCheckDistance = value; }
    public Transform LedgeCheck { get => ledgeCheck; set => ledgeCheck = value; }

    [SerializeField] public Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private float ledgeCheckDistance;
    [SerializeField] private Transform headCheck;
    [SerializeField] private float headCheckRadius;

    [SerializeField] public float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float wallCheckDistance;

    #region Check Functions

    public bool IsHeadColliding()
    {
        return Physics2D.OverlapCircle(headCheck.position, headCheckRadius, whatIsGround);
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.facingDirection, wallCheckDistance, whatIsGround);
    }

    public bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, ledgeCheckDistance,whatIsGround);
    }
    #endregion


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        if(headCheck != null)
            Gizmos.DrawWireSphere(headCheck.position, headCheckRadius);
    }
}
