using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedState : BaseState
{
    private Tile _childTile;
    public ClosedState(Tile tile, IStateSwitcher stateSwitcher,Tile childTile) : base(tile, stateSwitcher)
    {
        _childTile = childTile;
    }

    public override void EnterState()
    {
        _tile.OnTileClicked += OnClick;
        if(_childTile != null)
        {
            _childTile.SetCover(true);
        }
        
    }

    public override void ExitState()
    {
        _tile.OnTileClicked -= OnClick;
    }
    private void OnClick()
    {
        if (!_tile.isCovered)
        {
            _stateSwitcher.SwitchState<OpenState>();
        }
        else
        {
            _stateSwitcher.SwitchState<ClosedState>();
        }

        
        
    }
    public override void Perform()
    {
        _tile.SetColor(Color.gray);
    }
}