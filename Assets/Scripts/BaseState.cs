using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected readonly Tile _tile;
    protected readonly IStateSwitcher _stateSwitcher;

    protected BaseState(Tile tile,IStateSwitcher stateSwitcher)
    {
        _tile = tile;
        _stateSwitcher = stateSwitcher;
    }
    public abstract void Perform();
    public abstract void EnterState();
    public abstract void ExitState();
}
