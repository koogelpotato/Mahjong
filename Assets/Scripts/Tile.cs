using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IClickable
{
    [SerializeField]
    private TileDataDynamic _dynamicData;
    [SerializeField]
    private TileDataStatic _staticData;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Tile _parentTile = null;
    

    
    public Sprite sprite => _staticData.Sprite;
    public Color Color => _dynamicData.color;
    public bool IsClosed => _dynamicData.isClosed;

    public event Action OnTileClicked;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _dynamicData = new TileDataDynamic(_staticData);
        
    }
    private void Update()
    {
        
    }
    public bool IsDependent()
    {
        if(_parentTile == null)
            return false;
        return true;
    }
    public void OpenTile(bool boolean)
    {
        _dynamicData.isClosed = boolean;
    }
    public void SetColor(Color color)
    {
         _dynamicData.color = color;
         _spriteRenderer.color = _dynamicData.color;
    }
    public void SetParent()
    {
        transform.parent = _staticData.Parent;
    }
    public void DestroyTile()
    {
        Destroy(gameObject);
    }

    public void Click()
    {
        OnTileClicked?.Invoke();
    }
}
