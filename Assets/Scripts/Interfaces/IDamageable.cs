using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(AttackDetails amount);
    void Damage(AttackDetails amount, string StopOnlyYMovement);
    float GetKnockBackForceWhenHit();
    float GetKnockBackDurationWhenHit();
    float GetKnockBackForcePogoJump();
    float GetKnockBackDurationPogoJump();

}
