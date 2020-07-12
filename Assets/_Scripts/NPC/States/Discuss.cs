using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "State Discuss", menuName = "State Machine/States/Discuss")]
public class Discuss : State
{
    public override void InitState()
    {
        //stateMachine.GetComponent<Behaviour_Discuss>().enabled = true;
    }

    public override void UpdateState()
    {
        /*if (stateMachine.GetComponent<Behaviour_Discuss>().completed)
        {
            stateMachine.GetComponent<Behaviour_Discuss>().completed = false;
            stateMachine.GetComponent<Behaviour_Discuss>().enabled = false;
            ExitState();
        }*/
    }

    public override bool ExitState()
    {
        return base.ExitState();
    }
}
