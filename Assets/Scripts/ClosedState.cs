using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedState : BaseState
{
    public ClosedState(Tile tile, IStateSwitcher stateSwitcher) : base(tile, stateSwitcher)
    {
    }

    public override void EnterState()
    {
        _tile.OnTileClicked += OnClick;
    }

    public override void ExitState()
    {
        _tile.OnTileClicked -= OnClick;
    }
    private void OnClick()
    {
        if (!_tile.IsDependent())
            _stateSwitcher.SwitchState<OpenState>();
        _stateSwitcher.SwitchState<ClosedState>();
    }
    public override void Perform()
    {
        _tile.SetColor(Color.gray);
    }
}