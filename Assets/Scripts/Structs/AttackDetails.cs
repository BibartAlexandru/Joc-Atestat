using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AttackDetails
{
    public Vector2 position;
    public float damageAmount;
    public float knockBackForce;
    public float knockBackTime;
    public string attackDirection;
    public bool ignoresInvulnerability;

    public AttackDetails(Vector2 _position,float _damageAmount,float _knockBackForce,float _knockBackTime,string _attackDirection)
    {
        position = _position;
        damageAmount = _damageAmount;
        knockBackForce = _knockBackForce;
        knockBackTime = _knockBackTime;
        attackDirection = _attackDirection;
        ignoresInvulnerability = false;
    }
}
