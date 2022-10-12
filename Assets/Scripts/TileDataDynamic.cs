using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileDataDynamic
{
    public Color color;
    public bool isClosed;
    public TileDataDynamic(TileDataStatic data)
    {
        color = data.Color;
        isClosed = data.IsClosed;
    }
}
