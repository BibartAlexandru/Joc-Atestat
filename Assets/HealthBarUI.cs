using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image[] hearts;
    public Image[] revives;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite emptyRevive;
    public Sprite fullRevive;
    
    public void UpdateHealthBar(float currentHealth,float maxHealth,float currentRevives,float maxRevives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
        for(int i = 0; i < revives.Length; i++)
        {
            if (i < maxRevives)
                revives[i].enabled = true;
            else
                revives[i].enabled = false;
            if (i < currentRevives)
                revives[i].sprite = fullRevive;
            else
                revives[i].sprite = emptyRevive;
        }
    }
}
