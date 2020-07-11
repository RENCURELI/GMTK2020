using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Idle", menuName = "State Machine/States/Idle")]
public class Idle : State
{
    public override void InitState()
    {
        //stateMachine.GetComponent<Behaviour_Idle>().enabled = true;
    }

    public override void UpdateState()
    {
        /*if (stateMachine.GetComponent<Behaviour_Idle>().completed)
        {
            stateMachine.GetComponent<Behaviour_Idle>().completed = false;
            stateMachine.GetComponent<Behaviour_Idle>().enabled = false;
            ExitState();
        }*/
    }

    public override void ExitState()
    {
        ExitToTransition(0);
    }
}
