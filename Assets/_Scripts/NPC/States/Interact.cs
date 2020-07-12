using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Interact", menuName = "State Machine/States/Interact")]
public class Interact : State
{
    public override void InitState()
    {
        //stateMachine.GetComponent<Behaviour_Interact>().enabled = true;
    }

    public override void UpdateState()
    {
        /*if (stateMachine.GetComponent<Behaviour_Interact>().completed)
        {
            stateMachine.GetComponent<Behaviour_Interact>().completed = false;
            stateMachine.GetComponent<Behaviour_Interact>().enabled = false;
            ExitState();
        }*/
    }

    public override void ExitState()
    {
        ExitToTransition(0);
    }
}
