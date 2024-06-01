using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderWithGroundLayers : MonoBehaviour
{
    public float rotationModifier = 0f;
    public GameObject groundHitParticles,mazgaHitParticles,hitParticle;
    public GameObject soundBox;
    public AudioClip clip;

    public void PlayAnimName(string s)
    {
        //Debug.Log(s);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("da");
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 17 || collision.gameObject.layer == 22)
        {
            if (collision.gameObject.layer == 8 || collision.gameObject.layer == 17)
                hitParticle = groundHitParticles;
            else
                hitParticle = mazgaHitParticles;
            Vector2 direction = (Vector2)transform.parent.parent.parent.position - collision.ClosestPoint(transform.parent.parent.parent.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(hitParticle, collision.ClosestPoint(transform.parent.parent.parent.position), quaternion);
            GameObject g = Instantiate(soundBox, collision.ClosestPoint(transform.parent.parent.parent.position), Quaternion.identity);
            g.GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
