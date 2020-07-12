using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State MoveTo", menuName = "State Machine/States/MoveTo")]
public class MoveTo : State
{
    public override void InitState()
    {
        stateMachine.GetComponent<MovingBehaviour>().enabled = true;
    }

    public override void UpdateState()
    {
        if (stateMachine.GetComponent<MovingBehaviour>().completed)
        {
            stateMachine.GetComponent<MovingBehaviour>().completed = false;
            stateMachine.GetComponent<MovingBehaviour>().enabled = false;
            ExitState();
        }
    }

    public override bool ExitState()
    {
        base.ExitState();
        Transition(STATETYPE.IDLE);
        return true;
    }
}
