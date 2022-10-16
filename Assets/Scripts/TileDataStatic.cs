using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TileDataStatic : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private TileType tileType;
    [SerializeField]
    private Color color;
    [SerializeField]
    private bool isCovered = false;
    
    
    
    public Sprite Sprite { get => sprite; }
    public TileType TileType { get => tileType; }
    public Color Color { get => color; }
    public bool IsCovered { get => isCovered; }
}
public enum TileType
{
    Meat,
    Wine,
    Bread,
    Apple,
}
