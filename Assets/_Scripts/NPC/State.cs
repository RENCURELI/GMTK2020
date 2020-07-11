using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State : ScriptableObject
{
    [System.NonSerialized]
    public StateMachine stateMachine; //State machine the instance belongs too

    [System.NonSerialized]
    public State firstState; //Start state

    /// <summary>
    /// Manage state initialization and startup
    /// </summary>
    public virtual void InitState() { }

    /// <summary>
    /// Manage state Update
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Manage state transition, exit and disabling
    /// </summary>
    public virtual void ExitState() { }

    public virtual void OnStateMachineDisable() { }

    /// <summary>
    /// Move to next state
    /// </summary>
    public void ExitToTransition(int index)
    {
        StateMachine.Transitions transition = GetTransition(index);
        stateMachine.activeState.ExitState();
        if (transition != null)
        {
            transition.stateMachine.EnterState(transition.state);
        }
    }

    /// <summary>
    /// Select next state
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public StateMachine.Transitions GetTransition(int index)
    {
        StateMachine.StatePair pair = stateMachine.GetPairFromState(firstState);
        if (pair.transitions.Count <= index)
        {
            return null;
        }
        StateMachine.Transitions transitions = pair.transitions[index];
        return transitions;
    }

}
