using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData",menuName = "Data/Weapon Data/Weapon")]
public class SO_WeaponData : ScriptableObject
{
    public int maxAttackCounter = 2;
    public float damageAmount = 1f;
    public float knockBackForce = 10f;
    public float knockBackTime = 0.1f;
    public float[] attackRadiuses;
    public LayerMask whatIsDamageAble;
}
