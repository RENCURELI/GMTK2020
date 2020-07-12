using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Idle", menuName = "State Machine/States/Idle")]
public class Idle : State
{

    public float g_duration;
    public float g_timer;

    public override void InitState()
    {
        g_duration = 2.0f;
        g_timer = g_duration;
    }

    public override void UpdateState()
    {
        g_timer -= Time.deltaTime;
        if (g_timer <= 0)
        {
            ExitState();
        }
    }

    public override bool ExitState()
    {
        base.ExitState();
        Transition(STATETYPE.MOVETO);
        return true;
    }
}
