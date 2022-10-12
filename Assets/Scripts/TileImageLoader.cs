using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileImageLoader : MonoBehaviour
{
    private Tile _parentTile;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _parentTile = GetComponentInParent<Tile>();
        _spriteRenderer.sprite = _parentTile.sprite;
    }
}
