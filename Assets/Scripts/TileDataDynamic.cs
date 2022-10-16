using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileDataDynamic
{
    public Color color;
    public bool isCovered;
    public TileDataDynamic(TileDataStatic data)
    {
        color = data.Color;
        isCovered = data.IsCovered;
    }
}
