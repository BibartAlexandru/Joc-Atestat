using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private WeaponAnimationToWeapon toWeapon;
    public AttackDetails attackDetails;
    private Vector2 currentAttackPosition;
    private List<Collider2D> detectedDamageables = new List<Collider2D>();
    private Attack attack;
    private float attackRadius;
    [SerializeField] private SO_WeaponData weaponData;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Transform[] attackPoints;
    [SerializeField] private GameObject mazgaHitEffect;
    private Collider2D hitBoxCollider;
    private Collider2D collisionsThatKnockBackSelf;
    bool isAttacking;

    public SO_WeaponData WeaponData { get => weaponData; set => weaponData = value; }

    private void Update()
    {
        attackDetails.position = attack.player.transform.position;
        if (isAttacking)
            CheckTargets();
    }

    private void Awake()
    {
        toWeapon = transform.GetComponentInChildren<WeaponAnimationToWeapon>();
        attackDetails.damageAmount = weaponData.damageAmount;
        attackDetails.knockBackForce = weaponData.knockBackForce;
        attackDetails.knockBackTime = weaponData.knockBackTime;
        isAttacking = false;
    }

    public void AnimationStopAttackTrigger()
    {
        isAttacking = false;
    }

    public void AnimationFinishTrigger()
    {
        attack.StopAttack();
    }

    public void AnimationTurnOnFlipTrigger()
    {
        attack.TurnOnFlip();
    }

    public void AnimationTurnOffFlipTrigger()
    {
        attack.TurnOffFlip();
    }

    private void SetCurrentAttackPosition()
    {
        currentAttackPosition = attackPoints[attack.attackDirection].position;
    }

    private void InstantiateHitEffectAtAttackPosition()
    {
        Transform effectPosition;
        float xAdd = 0, yAdd = 0;
        if (attack.attackDirection == 2)
        {
            effectPosition = attackPoints[2];
            yAdd = -0.5f;
        }
        else if (attack.attackDirection == 1)
        {
            effectPosition = attackPoints[1];
            yAdd = 1.5f;
        }
        else
        {
            effectPosition = attackPoints[0];
            xAdd = 1.8f * attack.player.core.Movement.facingDirection;
        }
        GameObject.Instantiate(hitEffect, effectPosition.position + new Vector3(xAdd,yAdd), Quaternion.identity);
    }

    public virtual void AnimationStartAttackTrigger()
    {
        isAttacking = true;
        AudioManager.PlaySound("scythe_attack");
        SetCurrentAttackPosition();
        attackRadius = 0f;
        if (attack.attackDirection == 2 || attack.attackDirection == 1)
            attackRadius = weaponData.attackRadiuses[weaponData.attackRadiuses.Length - 1];
        else
            attackRadius = weaponData.attackRadiuses[attack.attackCounter % weaponData.maxAttackCounter];
        if (detectedDamageables.Count != 0)
        {
            InstantiateHitEffectAtAttackPosition();
            attack.player.events.smallCameraShake.Invoke();
            if (attack.attackDirection == 2)
                attack.player.jumpState.ResetExtraJumps();
        }
        
    }

    public void CheckTargets()
    {
        float force = 0f;
        float duration = 0f;
        Vector2 angle = Vector2.zero;
        bool esteMazga = false;
        IDamageable damageable = null;
        for (int i = 0; i < detectedDamageables.Count; i++)
        {
            damageable = detectedDamageables[i].GetComponent<IDamageable>();
            if (damageable != null)
            {
                detectedDamageables[i].GetComponent<IDamageable>().Damage(attackDetails);
                if (attack.attackDirection != 2)
                {
                    if (damageable.GetKnockBackForceWhenHit() > force)
                    {
                        force = damageable.GetKnockBackForceWhenHit();
                        duration = damageable.GetKnockBackDurationWhenHit();
                        angle = (attackDetails.position - (Vector2)detectedDamageables[i].GetComponentInParent<Core>().transform.position);
                    }
                }
                else
                {
                    if (damageable.GetKnockBackForcePogoJump() > force)
                    {
                        force = damageable.GetKnockBackForcePogoJump();
                        duration = damageable.GetKnockBackDurationPogoJump();
                        angle = Vector2.up;
                    }
                }
            }
            detectedDamageables.RemoveAt(i);
            i--;
           
        }
        if (force != 0 && attack.attackDirection != 1 && attack.attackDirection != 2)
            attack.player.core.Movement.KnockBack(force, duration, angle, 1);
        if (force != 0 && attack.attackDirection == 2)
        {
            attack.player.jumpState.ResetExtraJumps();
            attack.player.core.Movement.KnockBack(force, duration, angle, 1, "Yes");
        }
    }


    public IEnumerator TryCollisionsThatKnockBackSelf(int remainingTimes,Vector2 currentAttackPosition,float radius)
    {
        if(remainingTimes == 0)
            yield break;
        collisionsThatKnockBackSelf = Physics2D.OverlapCircle(currentAttackPosition, radius, attack.player.PlayerData.whatKnocksBackSelf);
        VerifyCollisionsThatKnockBackPlayer();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(TryCollisionsThatKnockBackSelf(remainingTimes - 1,currentAttackPosition,radius));
    }

    public void VerifyCollisionsThatKnockBackPlayer()
    {
        if (collisionsThatKnockBackSelf != null)
        {
            float force;
            float duration;
            Vector2 angle;
            if (attack.attackDirection != 2)
            {
                force = collisionsThatKnockBackSelf.GetComponentInParent<IDamageable>().GetKnockBackForceWhenHit();
                duration = collisionsThatKnockBackSelf.GetComponentInParent<IDamageable>().GetKnockBackDurationWhenHit();
                angle = -((Vector2)collisionsThatKnockBackSelf.transform.position - attackDetails.position);
            }
            else
            {
                force = collisionsThatKnockBackSelf.GetComponentInParent<IDamageable>().GetKnockBackForcePogoJump();
                duration = collisionsThatKnockBackSelf.GetComponentInParent<IDamageable>().GetKnockBackDurationPogoJump();
                angle = Vector2.up;
            }

            if (collisionsThatKnockBackSelf.GetComponentInParent<Mazga>() != null)
            {
                attack.player.core.Movement.KnockBack(force, duration, angle, 1, "Yessir");
                GameObject.Instantiate(mazgaHitEffect, currentAttackPosition + Vector2.down/2, Quaternion.identity);
            }
            else if(attack.attackDirection != 1)
                attack.player.core.Movement.KnockBack(force, duration, angle, 1);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<IDamageable>() != null && collision.gameObject.GetComponent<Combat>().isInvincible == false)
        {
            detectedDamageables.Add(collision);
        }
    }

    public void DoDamage(IDamageable damageable,Vector2 enemyPosition)
    {
        damageable.Damage(attackDetails);
    }

    public void SetAttack(Attack _attack)
    {
        attack = _attack;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawWireSphere(attackPoints[1].position, weaponData.attackRadiuses[0]);
    }

}
