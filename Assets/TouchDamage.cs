using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour
{
    private Core core;
    private void Awake()
    {
        core = transform.parent.GetComponentInChildren<Core>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && core != null)
        {
            core.Combat.DoTouchDamage(collision.GetComponentInParent<Player>().gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 && core != null)
        {// 10 e layeru player
            core.Combat.DoTouchDamage(collision.GetComponentInParent<Player>().gameObject);
        }
    }
}
