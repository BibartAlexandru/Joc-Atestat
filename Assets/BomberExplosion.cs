using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberExplosion : MonoBehaviour
{
    private Collider2D collider2D;
    AttackDetails attackDetails;
    [SerializeField] private float damageAmount;
    [SerializeField] private float knockBackForce;
    [SerializeField] private float knockBackDuration;
    private float timeUntilDestroy = 3f;

    private void Awake()
    {
        attackDetails.damageAmount = damageAmount;
        attackDetails.attackDirection = null;
        attackDetails.knockBackForce = knockBackForce;
        attackDetails.knockBackTime = knockBackDuration;
        attackDetails.position = transform.position;
    }

    private void Update()
    {
        if (timeUntilDestroy <= 0)
            GameObject.Destroy(this.gameObject);
        timeUntilDestroy -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponentInChildren<IDamageable>().Damage(attackDetails);
    }


}
