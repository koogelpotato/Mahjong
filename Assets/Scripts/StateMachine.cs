using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateMachine : MonoBehaviour, IStateSwitcher
{
    [SerializeField]
    private Tile _tile;

    private BaseState _currentState;
    private List<BaseState> _allStates;
    private void Update()
    {
        
    }
    private void Start()
    {
        _allStates = new List<BaseState>()
        {
            new ClosedState(_tile, this),
            new OpenState(_tile,this),
            new MovedState(_tile, this)
        };
        _currentState = _allStates[0];
        
    }
    public void Perform()
    {
        _currentState.Perform();
    }
    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        _currentState.ExitState();
        state.EnterState();
        _currentState = state;
    }
}
