using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]


public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public float attackDamage = 2f;
    public LayerMask whatIsPlayer;
    public float knockBackForce = 6f;
    public float knockBackTime = 0.2f;
}
