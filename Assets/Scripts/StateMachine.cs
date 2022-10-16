using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateMachine : MonoBehaviour, IStateSwitcher, IReturnCurrentState
{
    [SerializeField]
    private Tile _tile;
    [SerializeField]
    private Container _container;
    [SerializeField]
    private Tile _childTile;

    private BaseState _currentState;
    private List<BaseState> _allStates;
    private void Update()
    {
        
    }
    private void Start()
    {
        _allStates = new List<BaseState>()
        {
            new ClosedState(_tile, this, _childTile),
            new OpenState(_tile,this),
            new MovedState(_tile, this, _container,_childTile)
        };
        _currentState = _allStates[0];
        _currentState.EnterState();
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
        state.Perform();
        _currentState = state;
    }

    public BaseState ReturnCurrentState()
    {
        return _currentState;
    }
}
