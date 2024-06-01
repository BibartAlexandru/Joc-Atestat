using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedWallCombat : Combat
{
    public Sprite[] whileDamagedTextureSprites;
    public SpriteRenderer textureSpriteRenderer;

    private void Start()
    {
        textureSpriteRenderer.sprite = whileDamagedTextureSprites[(int)currentHealth - 1];
    }
    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if(currentHealth > 0)
            textureSpriteRenderer.sprite = whileDamagedTextureSprites[(int)currentHealth-1];
    }
}
