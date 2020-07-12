using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EXECUTIONSTATE
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED
};

public enum STATETYPE
{
    IDLE,
    MOVETO,
    INTERACT,
    DISCUSS
};

[System.Serializable]
public abstract class State : ScriptableObject
{
    [System.NonSerialized]
    public StateMachine stateMachine; //State machine the instance belongs too

    [System.NonSerialized]
    public State firstState; //Start state

    public State nextState;

    public EXECUTIONSTATE ExecutionState { get; protected set; }
    public bool EnteredState { get; protected set; }
    public STATETYPE StateType { get; protected set; }

    public virtual void OnEnable()
    {
        ExecutionState = EXECUTIONSTATE.ACTIVE;
    }

    /// <summary>
    /// Manage state initialization and startup
    /// </summary>
    public virtual void InitState()
    {
        ExecutionState = EXECUTIONSTATE.ACTIVE;
    }

    /// <summary>
    /// Manage state Update
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Manage state transition, exit and disabling
    /// </summary>
    public virtual bool ExitState()
    {
        ExecutionState = EXECUTIONSTATE.COMPLETED;
        return true;
    }

    public virtual void OnStateMachineDisable() { }

    /// <summary>
    /// Move to next state
    /// </summary>
    /*public void ExitToTransition(int index)
    {
        StateMachine.Transitions transition = GetTransition(index);
        stateMachine.activeState = null;
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
    }*/
    
    /*public void Transition(STATETYPE type)
    {
        if (stateMachine.states.ContainsKey(type))
        {
            nextState = stateMachine.states[type];

            stateMachine.EnterState(nextState, type);
        }
    }*/
}
