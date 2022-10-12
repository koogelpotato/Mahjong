using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenState : BaseState
{
    public OpenState(Tile tile, IStateSwitcher stateSwitcher) : base(tile, stateSwitcher)
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
        _stateSwitcher.SwitchState<MovedState>();
    }
    public override void Perform()
    {
        _tile.SetColor(Color.white);
    }
}
