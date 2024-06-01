using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable
{
    private HealthBarUI healthScript;
    public bool isDead { get; private set; }
    public HealthBarUI HealthScript { get => healthScript; private set => healthScript = value; }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public float RecoveryTime { get => recoveryTime; private set => recoveryTime = value; }
    public TimeStop timeStop { get; private set; }

    private IHealthUI healthUI;

    [SerializeField] private GameObject[] hitEffects;
    [SerializeField] private ParticleSystem[] aliveParticles;
    [SerializeField] private float knockBackForceResistance;
    [SerializeField] private Material matDefault;
    [SerializeField] private Material matWhite;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private float maxHealth;
    [SerializeField] private float recoveryTime;
    [SerializeField] private float knockBackForcePogoJump;
    [SerializeField] private float knockBackDurationPogoJump;
    [SerializeField] private float knockBackForceWhenHit;
    [SerializeField] private float knockBackDurationWhenHit;
    [SerializeField] private AudioClip groanSound,deathSound,hitSound;
    [SerializeField] public ParticleSystem invincibilityParticle;
    [SerializeField] public float touchDamage;
    [SerializeField] public float touchKnockBackForce;
    [SerializeField] public float touchKnockBackDuration;
    [SerializeField] private GameObject deathSoundObject;
    [SerializeField] private Color[] colorsAfterHit;

    public Color[] normalColors;
    public bool changeMaterialOnHit = true;
    public bool changeColorOnInvulnerable = false;
    public bool ignoresInvulnerability = false;
    public bool isInvincible;//{ get; private set; }
    public float currentHealth;

    private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        normalColors = new Color[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
            normalColors[i] = spriteRenderers[i].color;
        timeStop = core.GetComponentInParent<TimeStop>();
        animator = GetComponentInParent<Animator>();
        if (animator == null)
            animator = transform.parent.GetComponentInParent<Animator>();
        isDead = false;
        isInvincible = false;
        currentHealth = maxHealth;
        if(core.transform.parent.CompareTag("Player"))
            healthScript = GameObject.Find("PlayerHealthUI").GetComponent<HealthBarUI>();
    }

    #region IDamageable
    public float GetKnockBackForceWhenHit()
        {
             return knockBackForceWhenHit;
        }

        public float GetKnockBackDurationWhenHit()
        {
             return knockBackDurationWhenHit;
        }

        public float GetKnockBackForcePogoJump()
        {
            return knockBackForcePogoJump;
        }

        public float GetKnockBackDurationPogoJump()
        {
            return knockBackDurationPogoJump;
        }

    #endregion
    public void RestoreHP(float value)
    {
        currentHealth += value;
    }
    
    public void RestoreHP()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void SetInvinicibility(bool verdict)
    {
        isInvincible = verdict;
    }

    public void LogicUpdate()
    {
        if (healthScript != null)
            healthScript.UpdateHealthBar(currentHealth, maxHealth, core.player.gameManager.remainingRespawns, core.player.gameManager.maxRespawns);
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        if (core.audioSource != null)
        {
            if (hitSound)
                core.audioSource.PlayOneShot(hitSound);
            if (currentHealth - attackDetails.damageAmount > 0 && groanSound)
                core.audioSource.PlayOneShot(groanSound);
            else if (!isDead && deathSoundObject && deathSound && hitSound && (currentHealth - attackDetails.damageAmount <= 0))
            {
                GameObject g = Instantiate(deathSoundObject, transform.position, Quaternion.identity);
                g.GetComponent<AudioSource>().PlayOneShot(deathSound);
                g.GetComponent<AudioSource>().PlayOneShot(hitSound);
            }
        }
        if (transform.parent.parent.gameObject.CompareTag("Flower"))
        {
            if (attackDetails.attackDirection == "up")
                StartCoroutine(ChangeAnimation("HitDown")); //Am incurcat eu numele cand le-am facut is corecte asa
            else if (attackDetails.attackDirection == "down")
                StartCoroutine(ChangeAnimation("HitUp"));
            else if (attackDetails.attackDirection == "right")
                StartCoroutine(ChangeAnimation("HitRight"));
            else
                StartCoroutine(ChangeAnimation("HitLeft"));
        }
        if (!isDead)
        {
            if ((!isInvincible || attackDetails.ignoresInvulnerability == true) && !isDead)
            {
                /*
                if(core.audioSource != null)
                {
                    if(hitSound)
                        core.audioSource.PlayOneShot(hitSound);
                    if (currentHealth - attackDetails.damageAmount > 0 && groanSound)
                        core.audioSource.PlayOneShot(groanSound);
                    else if(deathSoundObject && deathSound && hitSound && (currentHealth - attackDetails.damageAmount <= 0)){ 
                        GameObject g = Instantiate(deathSoundObject, transform.position, Quaternion.identity);
                        g.GetComponent<AudioSource>().PlayOneShot(deathSound);
                        g.GetComponent<AudioSource>().PlayOneShot(hitSound);
                    }
                }
                */
                StartCoroutine(StartInvincibility(recoveryTime));
                //Debug.Log(core.transform.parent.name + " Damaged!");
                currentHealth -= attackDetails.damageAmount;
                if(changeMaterialOnHit == true)
                    StartCoroutine(ChangeMaterialOnHit());
                foreach (GameObject hitEffect in hitEffects)
                    Instantiate(hitEffect, new Vector3(transform.position.x,transform.position.y,1f), Quaternion.identity);
                if (core.Movement != null)
                {
                    core.Movement.KnockBack(attackDetails.knockBackForce / knockBackForceResistance, attackDetails.knockBackTime, ((Vector2)transform.position - attackDetails.position) * 100, 1);
                }

                if (core.transform.parent.CompareTag("Player"))
                {
                    GameObject g = Instantiate(core.transform.parent.GetComponent<Player>().soundBox,core.transform.parent.transform.position,Quaternion.identity);
                    g.GetComponent<AudioSource>().PlayOneShot(core.transform.parent.GetComponent<Player>().hurtSound);
                    timeStop.StopTime(0.01f, 10, 0.1f);
                }

                if (currentHealth <= 0)
                    isDead = true;
                if (core.transform.parent.CompareTag("Player") && !isDead)
                    timeStop.StopTime(0.01f, 10, 0.1f);
                if (core.transform.parent.CompareTag("Player"))
                    core.transform.parent.GetComponent<Player>().events.bigCameraShake.Invoke();
                if (transform.parent.parent.gameObject.CompareTag("Enemy"))
                {
                    if (attackDetails.attackDirection == "up")
                        StartCoroutine(ChangeAnimation("HitDown")); //Am incurcat eu numele cand le-am facut is corecte asa
                    else if (attackDetails.attackDirection == "down")
                        StartCoroutine(ChangeAnimation("HitUp"));
                    else if (attackDetails.attackDirection == "right")
                        StartCoroutine(ChangeAnimation("HitRight"));
                    else
                        StartCoroutine(ChangeAnimation("HitLeft"));
                }
            }
            if (isDead)
            {
                //Debug.Log(core.transform.parent.name + "Dead!");
                if(core.GetComponentInParent<IAlive>() != null)
                    core.GetComponentInParent<IAlive>().SwitchToDeadState();
            }
        }
    }

    public virtual void DoTouchDamage(GameObject target)
    {
        if (!isDead)
        {
            AttackDetails attackDetails = new AttackDetails(core.transform.position, touchDamage, touchKnockBackForce, touchKnockBackDuration, "");
            if (target.activeSelf)
                target.GetComponentInChildren<Core>().GetComponentInChildren<IDamageable>().Damage(attackDetails);
            if (core.Movement != null)
            {
                core.Movement.SetVelocity(0f, Vector2.zero, 1);
                if(core.gameObject.GetComponentInParent<Monoculus>() != null)
                    core.Movement.ChangeStopMovementForAmountOfTime(true, 0.5f);
            }
        }
    }

    public void Damage(AttackDetails attackDetails,string StopYMovement)
    {
        if (transform.parent.parent.gameObject.CompareTag("Flower"))
        {
            if (attackDetails.attackDirection == "up")
                StartCoroutine(ChangeAnimation("HitDown")); //Am incurcat eu numele cand le-am facut is corecte asa
            else if (attackDetails.attackDirection == "down")
                StartCoroutine(ChangeAnimation("HitUp"));
            else if (attackDetails.attackDirection == "right")
                StartCoroutine(ChangeAnimation("HitRight"));
            else
                StartCoroutine(ChangeAnimation("HitLeft"));
        }
        if (!isDead)
        {
            if ((!isInvincible || attackDetails.ignoresInvulnerability == true) && !isDead)
            {
                StartCoroutine(StartInvincibility(recoveryTime));
                //Debug.Log(core.transform.parent.name + " Damaged!");
                currentHealth -= attackDetails.damageAmount;
                if(changeMaterialOnHit == true)
                    StartCoroutine(ChangeMaterialOnHit());
                foreach (GameObject hitEffect in hitEffects)
                    Instantiate(hitEffect, transform.position, Quaternion.identity);
                if (core.Movement != null)
                {
                    core.Movement.KnockBack(attackDetails.knockBackForce / knockBackForceResistance, attackDetails.knockBackTime, ((Vector2)transform.position - attackDetails.position) * 100, 1,"Yessir");
                    //Debug.Log(knockBackForceResistance);
                }
                if (currentHealth <= 0)
                    isDead = true;
                if (core.transform.parent.CompareTag("Player") && !isDead)
                    timeStop.StopTime(0.01f, 10, 0.1f);
                if (transform.parent.parent.gameObject.CompareTag("Enemy"))
                {
                    if (attackDetails.attackDirection == "up")
                        StartCoroutine(ChangeAnimation("HitDown")); //Am incurcat eu numele cand le-am facut is corecte asa
                    else if (attackDetails.attackDirection == "down")
                        StartCoroutine(ChangeAnimation("HitUp"));
                    else if (attackDetails.attackDirection == "right")
                        StartCoroutine(ChangeAnimation("HitRight"));
                    else
                        StartCoroutine(ChangeAnimation("HitLeft"));
                }
            }
            if (isDead)
            {
                Debug.Log(core.transform.parent.name + "Dead!");
                core.GetComponentInParent<IAlive>().SwitchToDeadState();
            }
        }
    }


    public void SetKnockBackForceResistance(float value)
    {
        knockBackForceResistance = value;
    }
    IEnumerator ChangeAnimation(string hitAnimation)
    {
        animator.Play("Empty");
        animator.Play(hitAnimation);
        yield return new WaitForSeconds(1f);
        animator.Play("Empty");
    }
    IEnumerator ChangeMaterialOnHit()
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.material = matWhite;
        }

        if (aliveParticles.Length > 0)
            for (int i = 0; i < aliveParticles.Length; i++)
                aliveParticles[i].gameObject.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.material = matDefault;
        }

        if (aliveParticles.Length > 0)
            for (int i = 0; i < aliveParticles.Length; i++)
                aliveParticles[i].gameObject.SetActive(true);
    }

    public void StartInvincibilityCoRoutine(float timer)
    {
        StartCoroutine(StartInvincibility(timer));
    }

    public void SetColor(Color[] colors)
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
            spriteRenderers[i].color = colors[i];
    }

    private IEnumerator StartInvincibility(float timer)
    {
        isInvincible = true;
        if (invincibilityParticle != null && !isDead)
            invincibilityParticle.Play();
        if (changeColorOnInvulnerable == true)
            SetColor(colorsAfterHit);

        yield return new WaitForSeconds(timer);
        isInvincible = false;
        if (invincibilityParticle != null && !isDead)
            invincibilityParticle.Stop();
        if (changeColorOnInvulnerable == true)
            SetColor(normalColors);
    }

}
