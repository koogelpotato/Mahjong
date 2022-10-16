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
    private Tile _childTile = null;
    [SerializeField]
    private Container _container;
    

    
    public Sprite sprite => _staticData.Sprite;
    public Color Color => _dynamicData.color;
    public TileType type => _staticData.TileType;
    public bool isCovered => _dynamicData.isCovered;

    public event Action OnTileClicked;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _dynamicData = new TileDataDynamic(_staticData);
        
    }
    private void Update()
    {
        
    }
    public bool SetCover(bool IsCovered)
    {
            if (IsCovered)
            {
                _dynamicData.isCovered = true;
                return true;
            }
            else
            {
                _dynamicData.isCovered = false;
                return false;
            }   
    }
    
    public void SetColor(Color color)
    {
         _dynamicData.color = color;
         _spriteRenderer.color = _dynamicData.color;
    }
    public void SetParent(GameObject parentObject)
    {
        transform.SetParent(parentObject.transform);
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
