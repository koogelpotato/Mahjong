using UnityEngine;
public class MovedState : BaseState
{

    public MovedState(Tile tile, IStateSwitcher stateSwitcher) : base(tile, stateSwitcher)
    {
    }

    public override void EnterState()
    {
        Debug.Log("Entered move state");
    }

    public override void ExitState()
    {
        Debug.Log("Exited move state");
    }

    public override void Perform()
    {
        _tile.SetParent();
    }
}