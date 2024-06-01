using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private float speed;
    private bool restoreTime;

    private void Awake()
    {
        restoreTime = false;
    }

    public void Update()
    {
        if (restoreTime && !PauseMenu.isPaused)
        {
            if(Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * speed;
            }
            else
            {
                Time.timeScale = 1f;
                restoreTime = false;
            }
        }
    }

    public void StopTime(float changeTime,int restoreSpeed,float delay)
    {
        if (!PauseMenu.isPaused)
        {
            speed = restoreSpeed;
            if (delay > 0)
            {
                StopCoroutine(StartTimeAgain(delay));
                StartCoroutine(StartTimeAgain(delay));
            }
            else
            {
                restoreTime = true;
            }
            Time.timeScale = changeTime;
        }
    }

    IEnumerator StartTimeAgain(float amount)
    {
        if (!PauseMenu.isPaused)
        {
            restoreTime = true;
            yield return new WaitForSecondsRealtime(amount);
        }
    }
}
