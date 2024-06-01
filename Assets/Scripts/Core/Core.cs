using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    private Combat combat;
    private Movement movement;
    private CollisionSenses collisionSenses;
    public Player player;
    public AudioSource audioSource;

    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }

    public CollisionSenses CollisionSenses
    {
        get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }

    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    private void Awake()
    {
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Combat = GetComponentInChildren<Combat>();
        Movement = GetComponentInChildren<Movement>();
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void LogicUpdate()
    {
        movement.LogicUpdate();
        Combat.LogicUpdate();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(new Vector3(collisionSenses.WallCheck.position.x, collisionSenses.WallCheck.position.y), new Vector3(movement.facingDirection * collisionSenses.WallCheckDistance, collisionSenses.WallCheck.position.y));
    }
}
