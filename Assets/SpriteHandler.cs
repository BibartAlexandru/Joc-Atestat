using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;

    public void ChangeSpritesActiveState(bool newState)
    {
        foreach(SpriteRenderer sprite in spriteRenderers)
        {
            sprite.enabled = newState;
        }
    }
}
