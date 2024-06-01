using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazga : Entity
{

    public override void DoTouchDamage(GameObject player)
    {
        if (!core.Combat.isDead)
        {
            AttackDetails attackDetails = new AttackDetails(core.transform.position, entityData.touchDamage, entityData.touchKnockBackForce, entityData.touchKnockBackDuration, "");
            if (player.activeSelf)
                player.GetComponentInChildren<Core>().GetComponentInChildren<IDamageable>().Damage(attackDetails,"Yessir");
        }
    }

    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
    }

    
}
