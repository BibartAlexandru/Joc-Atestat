using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Weapon weapon;
    private Animator baseAnimator;
    private Animator colliderWithGroundAnimator;
    private Animator weaponAnimator;
    private SpriteHandler spriteHandler;
    public Player player;
    public int attackDirection;
    public float lastAttackTime { get; private set; }
    public float attackAnimationRecovery;
    public int attackCounter;
    public bool isAttacking;


    private void Awake()
    {
        player = GetComponent<Player>();
        spriteHandler = GetComponent<SpriteHandler>();
        isAttacking = false;
        attackDirection = 0;
    }

    public void SetWeapon(Weapon _weapon)
    {
        weapon = _weapon;
        weapon.SetAttack(this);
        baseAnimator = weapon.gameObject.transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = weapon.gameObject.transform.Find("Weapon").GetComponent<Animator>();
        colliderWithGroundAnimator = weapon.gameObject.transform.Find("WeaponGroundCollider").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time > lastAttackTime + attackAnimationRecovery)
            attackCounter = 0;
    }

    public void InitiateAttack()
    {
        attackDirection = player.GetAttackDirection();
        if (attackCounter >= weapon.WeaponData.maxAttackCounter)
            attackCounter = 0;
        lastAttackTime = Time.time;
        player.inputHandler.UsePrimaryAttackInput();
        StartAnimations();
        isAttacking = true;
    }

    public void StopAttack()
    {
        StopAnimations();

        attackCounter++;
        isAttacking = false;
    }

    private void StartAnimations()
    {
        if (attackDirection == 0)
        {
            if (attackCounter == 0)
            {
                baseAnimator.Play("Base_Scythe_Attack1");
                weaponAnimator.Play("ScytheAttack1");
                colliderWithGroundAnimator.Play("ScytheAttack1_GroundParticle");
            }
            else
            {
                baseAnimator.Play("Base_Scythe_Attack2");
                weaponAnimator.Play("ScytheAttack2");
                colliderWithGroundAnimator.Play("ScytheAttack2_GroundParticle");
            }
        }
        else if(attackDirection == 1)
        {
            baseAnimator.Play("Base_Scythe_Attack1");
            weaponAnimator.Play("ScytheAttackUp");
            colliderWithGroundAnimator.Play("UpAttack_GroundParticle");
        }
        else 
        {
            baseAnimator.Play("Base_Scythe_Attack1");
            weaponAnimator.Play("ScytheAttackDown");
            colliderWithGroundAnimator.Play("DownAttack_GroundParticle");
        }
        player.animator.enabled = false;
        spriteHandler.ChangeSpritesActiveState(false);
    }

    public void TurnOffFlip()
    {
        player.core.Movement.SetCanFlip(false);
    }

    public void TurnOnFlip()
    {
        player.core.Movement.SetCanFlip(true);
    }

    private void StopAnimations()
    {
        baseAnimator.Play("Empty");
        weaponAnimator.Play("Empty");
        colliderWithGroundAnimator.Play("Empty");
        player.animator.enabled = true;
        spriteHandler.ChangeSpritesActiveState(true);
    }

}
