using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
    private Weapon weapon;

    private void Awake()
    {
       weapon = GetComponentInParent<Weapon>();
    }
    public void AnimationFinishTrigger()
    {
        weapon.AnimationFinishTrigger();
    }

    public void AnimationTurnOnFlipTrigger()
    {
        weapon.AnimationTurnOnFlipTrigger();
    }

    public void AnimationTurnOffFlipTrigger()
    {
        weapon.AnimationTurnOffFlipTrigger();
    }

    public void AnimationStartAttackTrigger()
    {
        weapon.AnimationStartAttackTrigger();
    }

    public void AnimationStopAttackTrigger()
    {
        weapon.AnimationStopAttackTrigger();
    }
}
