using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Missle : MonoBehaviour
{

    [SerializeField] private string targetTag;
    [SerializeField] private float speed;
    [SerializeField] public bool canMove;
    private Rigidbody2D rigidbody2D;
    private Transform target;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag(targetTag) != null)
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(target == null)
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            if (target != null)
            {
                Vector2 direction = (Vector2)target.position - (Vector2)rigidbody2D.position;
                direction.Normalize();


                rigidbody2D.velocity = Vector2.one * direction * speed;
            }
        }
    }
}
