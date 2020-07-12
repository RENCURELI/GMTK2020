using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    #region Variables
    /*[System.Serializable]
    public class Transitions
    {
        public StateMachine stateMachine;
        public State state;
    }

    /// <summary>
    /// Pair a state with a following state (using a list for multiple followup state scenarios)
    /// </summary>
    [System.Serializable]
    public class StatePair
    {
        public State state;
        public List<Transitions> transitions = new List<Transitions>();
    }*/
    
    public List<State> validStates;
    public Dictionary<STATETYPE, State> states;
    /// <summary>
    /// List of all states on the current FSM
    /// </summary>
    //public List<StatePair> allStates;
    /// <summary>
    /// FSM Starting state
    /// </summary>
    public State startingState;
    /// <summary>
    /// Currently active state
    /// </summary>
    public State activeState;

#endregion

#region Methods
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        if (startingState != null)
        {
            EnterState(startingState);
        }
    }

    /// <summary>
    /// Initialize states used by FSM
    /// </summary>
    void Init()
    {

        states = new Dictionary<STATETYPE, State>();

        foreach (State state in validStates)
        {
            if (!states.ContainsKey(0))
            {
                states.Add(state.StateType, state);
            }
        }
        /*var stateToCopy = new Dictionary<State, State>();
        
        foreach (StatePair pair in allStates)
        {
            //If potential state not in dictionnary, add state to dictionnary
            if (!stateToCopy.ContainsKey(pair.state))
            {
                var m_temp = Instantiate(pair.state);
                m_temp.firstState = pair.state;
                m_temp.stateMachine = this;

                stateToCopy.Add(pair.state, m_temp);
            }
            pair.state = stateToCopy[pair.state];
        }*/
    }

    /*public StatePair GetPairFromState(State state)
    {
        foreach (StatePair pair in allStates)
        {
            if (pair.state.firstState == state)
            {
                return pair;
            }
        }
        return null;
    }

    public void EnterState(State state)
    {
        foreach (StatePair pair in allStates)
        {
            if (pair.state.firstState == state)
            {
                pair.state.InitState();
                activeState = pair.state;
                return;
            }
        }
    }*/

    public void EnterState(State state)
    {
        state.InitState();
    }


    private void Update()
    {
        if (activeState != null)
        {
            activeState.UpdateState();
        }
    }

    private void OnDisable()
    {
        if (activeState != null)
        {
            //activeState.OnStateMachineDisable();
            activeState.ExitState();
            activeState = null;
        }
    }

    private void OnEnable()
    {
        if (activeState == null)
        {
            EnterState(startingState);
        }
    }
    #endregion
}
