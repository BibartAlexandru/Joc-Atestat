using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Entity
{
    #region State Variables
    public Bomber_IdleState idleState { get; private set; }
    public Bomber_MoveState moveState { get; private set; }
    public Bomber_PlayerDetectedState playerDetectedState { get; private set; }
    public Bomber_ExplosionState explosionState { get; private set; }
    public Bomber_HandAttackState handAttackState { get; private set; }
    public Bomber_RecoveryState recoveryState { get; private set; }
    public Bomber_DeadState deadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetected playerDetectedStateData;
    [SerializeField] private D_RecoveryStateData recoveryStateData;
    [SerializeField] private D_DeadState deadStateData;
    #endregion

    [SerializeField] public float timeBetweenSpikeSpawn;
    [SerializeField] public GameObject spike;
    [SerializeField] public LayerMask canSpawnSpike;
    [SerializeField] public Vector2 distanceFromFirstSpikeMin;
    [SerializeField] public Vector2 distanceFromFirstSpikeMax;
    [SerializeField] public Vector2 distanceBetweenSpikes;
    [SerializeField] public ParticleSystem priorExplosionParticles;
    [SerializeField] public GameObject explosionParticles;
    [SerializeField] public ParticleSystem smoke;
    [SerializeField] public GameObject dustParticles;
    [SerializeField] private Transform palmaSt;
    [SerializeField] private Transform palmaDr;
    private AudioSource audioSource;
    [SerializeField] public AudioClip handsHitGround, smokeSound, ChargeBombSound, ExplosionSound,duringHandAttackSound,sleepSound;


    #region Unity Callback Functions
    public override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        idleState = new Bomber_IdleState(this, stateMachine, "Idle" , idleStateData , this);
        moveState = new Bomber_MoveState(this, stateMachine, "Walk", moveStateData , this);
        playerDetectedState = new Bomber_PlayerDetectedState(this, stateMachine, "PlayerDetected", playerDetectedStateData, this);
        handAttackState = new Bomber_HandAttackState(this, stateMachine, "HandAttack", null, this);
        explosionState = new Bomber_ExplosionState(this, stateMachine, "Explosion", null, this);
        recoveryState = new Bomber_RecoveryState(this, stateMachine, "Rest", recoveryStateData, this);
        deadState = new Bomber_DeadState(this, stateMachine, "Death", deadStateData, this);

    }
    #endregion

    public void Start()
    {
        stateMachine.Initialize(idleState);
    }


    public override void Update()
    {
        base.Update();
        //Debug.Log(stateMachine.currentState.ToString());
    }

    #region Other Functions

    public override void SwitchToDeadState()
    {
        base.SwitchToDeadState();
        stateMachine.ChangeState(deadState);
    }

    public void SetVoidHeartToIdle()
    {

    }

    public void SetVoidHeartToHandAttack()
    {

    }

    public void FinishRecovery()
    {
        recoveryState.SetRecovery(true);
    }

    public void PlayPriorExplosionParticles()
    {
        if (priorExplosionParticles != null)
        {
            priorExplosionParticles.gameObject.active = true;
        }
    }

    public void StopPriorExplosionParticles()
    {
        if (priorExplosionParticles != null)
        {
            priorExplosionParticles.gameObject.active = false;
        }
    }

    public void PlayExplosionParticles()
    {
        StopPriorExplosionParticles();
        if (explosionParticles != null)
            GameObject.Instantiate(explosionParticles, transform.Find("Center").transform.position, Quaternion.identity);
    }

    public void PlayDustParticles()
    {
        if (dustParticles != null)
        {
            GameObject.Instantiate(dustParticles, palmaSt.position, Quaternion.identity);
            GameObject.Instantiate(dustParticles, palmaDr.position, Quaternion.identity);
        }
    }

    public void StartSmoke()
    {
        if (smoke != null)
            smoke.Play();
    }

    public void StopSmoke()
    {
        if (smoke != null)
            smoke.Stop();
    }

    #endregion

    #region Sound playing for animations
    public void PlayHandsHitGround()
    {
        audioSource.PlayOneShot(handsHitGround);
    }

    public void PlaySmokeSound()
    {
        audioSource.PlayOneShot(smokeSound);
    }

    public void PlayDuringHandAttackSound()
    {
        audioSource.clip = duringHandAttackSound;
        audioSource.Play();
    }

    public void PlayBombChargingSound()
    {
        audioSource.PlayOneShot(ChargeBombSound);
    }

    public void PlayExlposionSound()
    {
        audioSource.PlayOneShot(ExplosionSound);
    }

    public void SetClipToNull()
    {
        audioSource.clip = null;
    }
    #endregion
}
