using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    private Vector2 workspace;
    public Vector2 currentVelocity { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }
    public bool stopMovement { get; private set; }
    public bool stopYMovement { get; private set; }
    public int facingDirection { get; private set; }
    public Transform FacingPlayerCheckDownLeft { get => facingPlayerCheckDownLeft; set => facingPlayerCheckDownLeft = value; }
    public Transform FacingPlayerCheckUpRight { get => facingPlayerCheckUpRight; set => facingPlayerCheckUpRight = value; }
    public string walkSound;
    public float walkSoundRate,lastTimePlayedWalkSound = 0f;
    private bool isFallingSoundPlaying = false;
    public AudioSource fallSoundSource;

    [SerializeField] float playerCheckRadius;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] Transform facingPlayerCheckDownLeft;
    [SerializeField] Transform facingPlayerCheckUpRight;

    private bool canFlip;

    #region Set Functions

    protected override void Awake()
    {
        base.Awake();
        facingDirection = 1;
        rigidbody2D = GetComponentInParent<Rigidbody2D>();
        canFlip = true;
        stopMovement = false;
    }

    private void Update()
    {
        if (fallSoundSource != null)
        {
            if (currentVelocity.y < -20f && !isFallingSoundPlaying)
            {
                fallSoundSource.Play();
                isFallingSoundPlaying = true;
            }
            if(core.CollisionSenses.CheckIfGrounded() || currentVelocity.y > 0f)
            {
                fallSoundSource.Pause();
                isFallingSoundPlaying = false;
            }
        }
        
    }

    public virtual bool isFacingPlayer()
    {
        return Physics2D.OverlapArea(facingPlayerCheckDownLeft.position, facingPlayerCheckUpRight.position, whatIsPlayer) != null;
    }
    public void KnockBack(float force,float duration,Vector2 angle,int direction)
    {
        StartCoroutine(KnockBackTimer(force,duration, angle, direction));
    }

    public void KnockBack(float force, float duration, Vector2 angle, int direction,string StopYMovement)
    {
        StartCoroutine(KnockBackTimerY(force, duration, angle, direction));
    }

    IEnumerator KnockBackTimer(float force,float duration,Vector2 angle,int direction)
    {
        SetVelocity(force, angle, direction);
        stopMovement = true;
        yield return new WaitForSeconds(duration);
        stopMovement = false;
        SetVelocity(0, Vector2.one, 1);
    }

    IEnumerator KnockBackTimerY(float force, float duration, Vector2 angle, int direction)
    {
        SetVelocity(force, angle, direction);
        stopYMovement = true;
        yield return new WaitForSeconds(duration);
        stopYMovement = false;
        SetVelocity(0, Vector2.one, 1);
    }

    public void SetFacingDirection(int newDirection)
    {
        facingDirection = newDirection;
    }

    public void LogicUpdate()
    {
        currentVelocity = rigidbody2D.velocity;
    }

    public void SetCanFlip(bool verdict)
    {
        canFlip = verdict;
    }

    public void ChangeStopMovementForAmountOfTime(bool verdict,float time)
    {
        StartCoroutine(SetStopMovement(verdict, time));
    }
    IEnumerator SetStopMovement(bool verdict,float time)
    {
        stopMovement = verdict;
        yield return new WaitForSeconds(time);
        stopMovement = !verdict;
    }

    public void SetStopMovement(bool verdict)
    {
        stopMovement = verdict;
    }
    public void SetVelocityX(float newVelocity)
    {
        if (!stopMovement)
        {
            workspace.Set(newVelocity, rigidbody2D.velocity.y);
            rigidbody2D.velocity = workspace;
            currentVelocity = workspace;
            if ((newVelocity > 0.3f || newVelocity < -0.3f) && Time.time >= lastTimePlayedWalkSound + walkSoundRate && walkSound != null && core.CollisionSenses.CheckIfGrounded())
            {
                lastTimePlayedWalkSound = Time.time;
                AudioManager.PlaySound(walkSound);
            }
        }
    }

    public void SetVelocityY(float newVelocity)
    {
        if (!stopMovement && !stopYMovement)
        {
            workspace.Set(rigidbody2D.velocity.x, newVelocity);
            rigidbody2D.velocity = workspace;
            currentVelocity = workspace;
        }
    }
    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        if (!stopMovement && !stopYMovement)
        {
            angle.Normalize();
            workspace.Set(angle.x * velocity * direction, angle.y * velocity);
            rigidbody2D.velocity = workspace;
            currentVelocity = workspace;
        }
    }
    #endregion

    public void Flip()
    {
        facingDirection *= -1;
        rigidbody2D.transform.Rotate(0f, 180f, 0f);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != facingDirection && canFlip && !PauseMenu.isPaused)
            Flip();
    }
}
