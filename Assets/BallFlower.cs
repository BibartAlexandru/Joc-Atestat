using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlower : MonoBehaviour,IAlive
{
    private Animator anim;
    [SerializeField] private GameObject effect;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    #region IAlive 
    public void SwitchToAliveState()
    {
        ActivateFlowers();
    }

    public void ChangeToIdleAnimation()
    {
        anim.Play("Idle");
    }

    public void PlayEffects()
    {
        //Debug.Log("j");
        Instantiate(effect, transform.position, Quaternion.identity);
    }

    public void SwitchToDeadState()
    {
        anim.Play("PopFlowers");
    }
    #endregion

    public void DeactivateFlowers()
    {
        transform.FindChild("Flowers").gameObject.SetActive(false);
    }

    public void ActivateFlowers()
    {
        transform.FindChild("Flowers").gameObject.SetActive(true);
    }

    public void DoTouchDamage(GameObject target)
    {
    }
}
