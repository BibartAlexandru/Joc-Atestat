using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, IAlive
{
    public void SwitchToAliveState()
    {
        
    }

    public void SwitchToDeadState()
    {
        GameObject.Destroy(this.gameObject);
    }
}
