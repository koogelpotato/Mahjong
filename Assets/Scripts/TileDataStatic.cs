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
    private Transform tileParent;
    [SerializeField]
    private bool isClosed;
    [SerializeField]
    private bool isDependent;
    public Sprite Sprite { get => sprite; }
    public TileType TileType { get => tileType; }
    public Color Color { get => color; }
    public Transform Parent { get => tileParent; }
    public bool IsClosed { get => isClosed; }
    public bool IsDependent { get => isDependent; }


}
public enum TileType
{
    Meat,
    Wine,
    Bread,
    Apple,
}
