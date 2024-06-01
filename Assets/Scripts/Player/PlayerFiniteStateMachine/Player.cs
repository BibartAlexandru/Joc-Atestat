using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour,IAlive
{
    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerInAirState inAirState { get; private set; }
    public PlayerLandState landState { get; private set; }
    public PlayerJumpHoldState jumpHoldState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerAttackState primaryAttackState { get; private set; }
    public PlayerDeadState deadState { get; private set; }
    public PlayerRespawnState respawnState { get; private set; }


    [SerializeField] private PlayerData playerData;
    public PlayerData PlayerData { get => playerData; set => playerData = value; }

    #endregion

    #region Components
    public Animator animator;
    public PlayerInputHandler inputHandler { get; private set; }    
    public PlayerInventory inventory { get; private set; }
    public Core core { get; private set; }
    public Attack attack { get; private set; }
    public PlayerToGameManager playerToGameManager { get; private set; }
    #endregion

    #region Other Variables
    public UnityEvent spawnPlayer;
    public Unity_Events events;
    private HealthBarUI healthScript;
    public GameManager gameManager;
    public GameObject audioListenerCandMoare;
    public GameObject currentAudioListenerAfterDeath;
    [SerializeField] public GameObject jumpEffect;
    [SerializeField] public GameObject changeLayerEffect,soundBox; //Ca sa nu mai il atace inamicii
    [SerializeField] public AudioClip hurtSound,wallSlideSound,teleportBegin,teleportEnd;
    public Image body, eyes;
    public float maxDashDistance, dashCheckRadius, dashXOffset = 0;
    public Collider2D standingCollider;
    public Animator playerDeathScreenAnimator;
    public float dashDirection;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        core = GetComponentInChildren<Core>();
        events = GameObject.Find("Events").GetComponent<Unity_Events>();
        healthScript = GameObject.Find("PlayerHealthUI").GetComponent<HealthBarUI>();

        playerToGameManager = GetComponent<PlayerToGameManager>();
        stateMachine = new PlayerStateMachine();
        inputHandler = GetComponent<PlayerInputHandler>();
        idleState = new PlayerIdleState(this,stateMachine,playerData,"Idle");
        moveState = new PlayerMoveState(this, stateMachine, playerData, "Walk");
        jumpState = new PlayerJumpState(this, stateMachine, playerData, "Jump");
        inAirState = new PlayerInAirState(this, stateMachine, playerData, "InAir");
        landState = new PlayerLandState(this, stateMachine, playerData,"Land");
        jumpHoldState = new PlayerJumpHoldState(this, stateMachine, playerData, "InAir");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, playerData, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, playerData, "InAir");
        deadState = new PlayerDeadState(this, stateMachine, playerData, "Dead");
        dashState = new PlayerDashState(this,stateMachine,playerData,"Dash",GetComponent<Rigidbody2D>().gravityScale);
        respawnState = new PlayerRespawnState(this, stateMachine, playerData, "Idle");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        inventory = GetComponent<PlayerInventory>();
        attack = GetComponent<Attack>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        attack.SetWeapon(inventory.weapons[0]);
        stateMachine.Initialize(idleState);
        core.Combat.StartInvincibilityCoRoutine(1f);
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            core.LogicUpdate();
            stateMachine.currentState.LogicUpdate();
            //Debug.Log(stateMachine.currentState.animation);
        }

        if (core.CollisionSenses.CheckIfTouchingWall() == false)
            dashDirection = core.Movement.facingDirection;
        else
        {
            dashDirection = -core.Movement.facingDirection;
            //core.Movement.Flip();
        }
    }

    public void PlayPlayerDashEndAnimation(int a)
    {
        dashState.Dash();
        animator.Play("DashEnd");
    }

    public void SetFillAmountBody(float fill)
    {
        body.fillAmount = fill;
    }

    public void SetFillAmoundEyes(float fill)
    {
        eyes.fillAmount = fill;
    }

    public void DisableObject()
    {
        this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion

    #region Check Functions

    public bool CanAttack()
    {
        if (Time.time > attack.lastAttackTime + playerData.attackCooldown)
            return true;
        return false;
    }
    #endregion

    #region Other Functions

    public void ResetPlayer()
    {
        //playerDeathScreenAnimator.Play("PlayerDeathScreenEnd");
        core.Combat.SetColor(core.Combat.normalColors);
        Destroy(currentAudioListenerAfterDeath);
        this.gameObject.AddComponent<AudioListener>();
        GetComponent<Rigidbody2D>().gravityScale = 5;
        core.Combat.RestoreHP();
        core.Movement.SetStopMovement(false);
        core.Combat.StartInvincibilityCoRoutine(1f);
        stateMachine.ChangeState(idleState);
    }

    public void SwitchToDeadState()
    {
        Destroy(GetComponent<AudioListener>());
        stateMachine.ChangeState(deadState);
    }
    public void SwitchToAliveState()
    {
        stateMachine.ChangeState(idleState);
    }

    public int GetAttackDirection()
    {
        if (inputHandler.rawMovementInput.y < 0.5f && inputHandler.rawMovementInput.y > -0.5f)
        {
            return 0;
        }
        else if (inputHandler.rawMovementInput.y >= 0.5f)
        { 
            return 1; // sus
        }
        else
        {
            return 2; //jos
        }
    }

    public void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.right * maxDashDistance * core.Movement.facingDirection, dashCheckRadius);
    }

    //Nu uita sa veerifici daca se colliduieste cu ground ca sa opresti dashul
    #endregion
}