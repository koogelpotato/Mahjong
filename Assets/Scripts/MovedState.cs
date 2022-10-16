using UnityEngine;
public class MovedState : BaseState
{
    private Container _container;
    private Tile _childTile;
    public MovedState(Tile tile, IStateSwitcher stateSwitcher, Container container,Tile childTile ) : base(tile, stateSwitcher)
    {
        _container = container;
        _childTile = childTile;
    }

    public override void EnterState()
    {
        _tile.OnTileClicked += OnClick;
        if(_childTile != null)
            _childTile.SetCover(false);
        _container.AssignPosition(_tile);
        _container.GainTileData(_tile);
    }

    public override void ExitState()
    {
        
    }

    public override void Perform()
    {
        Debug.Log("Tile moved");
    }

    private void OnClick()
    {
        _tile.OnTileClicked -= OnClick;
    }
    
}