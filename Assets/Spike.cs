using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour,ISpawnable
{
    protected Collider2D collider2D;
    protected Animator animator;
    private Bomber parent;
    [SerializeField] private float damageAmount;
    [SerializeField] private float knockBackForce;
    [SerializeField] private float knockBackTime;
    [SerializeField] protected AudioClip spikeRise,spikeSpawn;
    protected AudioSource audioSource;
    public bool ignoresInvulnerability = false;

    protected virtual void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        animator.Play("Spike Rises");
        audioSource = GetComponent<AudioSource>();
        if (spikeSpawn != null)
        audioSource.PlayOneShot(spikeSpawn);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Helo");
            AttackDetails attackDetails = new AttackDetails(transform.position,damageAmount,knockBackForce,knockBackTime,"Up");
            attackDetails.ignoresInvulnerability = ignoresInvulnerability;
            collision.gameObject.GetComponentInChildren<IDamageable>().Damage(attackDetails,"Yessir");
        }
    }

    public void GetParent(GameObject gameObject)
    {
        parent = gameObject.GetComponent<Bomber>();
    }

    public void PlaySpikeRiseSound()
    {
        audioSource.PlayOneShot(spikeRise);
    }

    public void DestroyGameObject()
    {
        if(parent != null)
            parent.handAttackState.AddDestroyedSpikes();
        Destroy(transform.parent.parent.gameObject);
    }
}
