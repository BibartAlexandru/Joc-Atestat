using UnityEngine;

public class Entity : MonoBehaviour, IAlive
{

    public FiniteStateMachine stateMachine;
    public Animator animator { get; private set; }
    [HideInInspector] public int lastDamageDirection { get; private set; }

    [HideInInspector] public float lastMeleeAttackTime;

    public Core core { get; private set; }

    public AnimationToStateMachine animationToStateMachine { get; private set; }
    public GameObject Player { get => player; private set => player = value; }
    public Transform TopOfHead { get => topOfHead; private set => topOfHead = value; }

    [SerializeField] private Transform center;
    [SerializeField] private Transform topOfHead;
    [SerializeField] private Transform bigAgroRangePlayerCheckCornerLeft;
    [SerializeField] private Transform bigAgroRangePlayerCheckCornerRight;
    [SerializeField] private Transform smallAgroRangePlayerCheckCornerLeft;
    [SerializeField] private Transform smallAgroRangePlayerCheckCornerRight;
    [SerializeField] private Material matDefault;
    [SerializeField] private Material matWhite;
    [SerializeField] public GameObject mazgaFootStepParticle;
    [SerializeField] public float footSpedParticleCooldown;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    public LayerMask mazgaLayer;
    private GameManager gameManager;

    private GameObject player;

    public D_Entity entityData;

    private float knockBackDuration;

    #region Unity Callback Functions
    public virtual void Awake()
    {
        core = GetComponentInChildren<Core>();
        animator = GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
        animationToStateMachine = GetComponent<AnimationToStateMachine>();
        lastMeleeAttackTime = -1f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = gameManager.player;
    }

    public virtual void SwitchToDeadState()
    {

    }

    public virtual void SwitchToAliveState()
    {

    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {

        stateMachine.currentState.PhysicsUpdate();
    }

    #endregion

    #region Check Function
    public virtual bool CheckPlayerInSmallAgroRange()
    {
        return Physics2D.OverlapArea(smallAgroRangePlayerCheckCornerLeft.position, smallAgroRangePlayerCheckCornerRight.position, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(center.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInBigAgroRange()
    {
        return Physics2D.OverlapArea(bigAgroRangePlayerCheckCornerLeft.position, bigAgroRangePlayerCheckCornerRight.position, entityData.whatIsPlayer);
    }

    #endregion

    #region Other Functions

    public virtual void DoTouchDamage(GameObject player)
    {
        if (!core.Combat.isDead)
        {
            AttackDetails attackDetails = new AttackDetails(core.transform.position, entityData.touchDamage, entityData.touchKnockBackForce, entityData.touchKnockBackDuration, "");
            if (player.activeSelf)
                player.GetComponentInChildren<Core>().GetComponentInChildren<IDamageable>().Damage(attackDetails);
        }
    }

    #endregion

    #region Gizmos
    public virtual void OnDrawGizmos()
    {
        
        if (core != null)
        {
            Gizmos.color = Color.green;
            if (core.CollisionSenses != null)
            {
                Gizmos.DrawLine(core.CollisionSenses.WallCheck.position, core.CollisionSenses.WallCheck.position + (Vector3)(Vector2.right * core.Movement.facingDirection * core.CollisionSenses.WallCheckDistance));
                Gizmos.DrawLine(core.CollisionSenses.LedgeCheck.position, core.CollisionSenses.LedgeCheck.position + (Vector3)(Vector2.down * core.CollisionSenses.LedgeCheckDistance));
                Gizmos.DrawWireSphere(core.CollisionSenses.GroundCheck.position, entityData.groundCheckRadius);
            }
            Gizmos.color = Color.yellow;

            Gizmos.color = Color.white;
            if (core.Movement != null)
            {
                Gizmos.DrawLine(core.Movement.FacingPlayerCheckDownLeft.position, new Vector3(core.Movement.FacingPlayerCheckDownLeft.position.x, core.Movement.FacingPlayerCheckUpRight.position.y, 0f));
                Gizmos.DrawLine(new Vector3(core.Movement.FacingPlayerCheckDownLeft.position.x, core.Movement.FacingPlayerCheckUpRight.position.y, 0f), core.Movement.FacingPlayerCheckUpRight.position);
                Gizmos.DrawLine(core.Movement.FacingPlayerCheckUpRight.position, new Vector3(core.Movement.FacingPlayerCheckUpRight.position.x, core.Movement.FacingPlayerCheckDownLeft.position.y, 0f));
                Gizmos.DrawLine(new Vector3(core.Movement.FacingPlayerCheckUpRight.position.x, core.Movement.FacingPlayerCheckDownLeft.position.y, 0f), core.Movement.FacingPlayerCheckDownLeft.position);
            }

            Gizmos.color = Color.blue;
            if (bigAgroRangePlayerCheckCornerLeft != null)
            {
                Gizmos.DrawLine(bigAgroRangePlayerCheckCornerLeft.position, new Vector2(bigAgroRangePlayerCheckCornerRight.position.x, bigAgroRangePlayerCheckCornerLeft.position.y));
                Gizmos.DrawLine(bigAgroRangePlayerCheckCornerLeft.position, new Vector2(bigAgroRangePlayerCheckCornerLeft.position.x, bigAgroRangePlayerCheckCornerRight.position.y));
                Gizmos.DrawLine(new Vector2(bigAgroRangePlayerCheckCornerLeft.position.x, bigAgroRangePlayerCheckCornerRight.position.y), bigAgroRangePlayerCheckCornerRight.position);
                Gizmos.DrawLine(bigAgroRangePlayerCheckCornerRight.position, new Vector2(bigAgroRangePlayerCheckCornerRight.position.x, bigAgroRangePlayerCheckCornerLeft.position.y));

                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(smallAgroRangePlayerCheckCornerLeft.position, new Vector2(smallAgroRangePlayerCheckCornerRight.position.x, smallAgroRangePlayerCheckCornerLeft.position.y));
                Gizmos.DrawLine(smallAgroRangePlayerCheckCornerLeft.position, new Vector2(smallAgroRangePlayerCheckCornerLeft.position.x, smallAgroRangePlayerCheckCornerRight.position.y));
                Gizmos.DrawLine(new Vector2(smallAgroRangePlayerCheckCornerLeft.position.x, smallAgroRangePlayerCheckCornerRight.position.y), smallAgroRangePlayerCheckCornerRight.position);
                Gizmos.DrawLine(smallAgroRangePlayerCheckCornerRight.position, new Vector2(smallAgroRangePlayerCheckCornerRight.position.x, smallAgroRangePlayerCheckCornerLeft.position.y));

                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(center.position + (Vector3)(Vector2.right * core.Movement.facingDirection * entityData.closeRangeActionDistance), 0.2f);
                Gizmos.DrawLine(center.position, new Vector2(center.position.x + entityData.closeRangeActionDistance, center.position.y));
            }
        }
        
    }
    #endregion
}
