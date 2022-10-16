using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Container : MonoBehaviour, IAssignPosition, IGainTileData
{
    [SerializeField]
    private int _lossTreshold;
    [SerializeField]
    private List<ContainerCell> _cells = new List<ContainerCell>();

    private List<TileType> _types = new List<TileType>();
    private List<Tile> _tiles = new List<Tile>();
    private int _containerCellCount = 0;
    

    public event Action PlayerDefeat;
    public void GainTileData(Tile tile)
    {
        _types.Add(tile.type);
        _tiles.Add(tile);

    }
    public void AssignPosition(Tile tile)
    {
        foreach (var cell in _cells)
        if (!cell.IsUsed)
        {
            tile.SetParent(cell.transform.gameObject);
            tile.transform.position = cell.transform.position;
            cell.SetUse(true);
            _containerCellCount++;
            CountTileTypes();
            break;
        }
        else
        {
            FreeUpCell(cell);
            continue;
        }
    }
        private void Start()
        {

        }
        private void Update()
        {
            Debug.Log(_containerCellCount);
            CellCountThresholdCheck();
            CountTileTypes();
        }
        private void CalculatePosition(Tile tile)
        {
            foreach (var cell in _cells)
            {
                if (cell.IsUsed)
                    continue;
                else
                {
                    tile.SetParent(cell.gameObject);
                    tile.transform.position = cell.transform.position;
                    break;
                }

            }
        }
        private void CellCountThresholdCheck()
        {
            if (_containerCellCount >= _lossTreshold)
            {
                PlayerDefeat?.Invoke();
            }
        }
        private void CountTileTypes()
        {
            foreach (var g in _types.GroupBy(x => x).OrderBy(g => g.Key))
            {
                if (g.Count() > 2)
                {
                    DestroyTiles(g.Key);
                    _types.RemoveAll(x => x == g.Key);
                }
            }

        }
        private void DestroyTiles(TileType tileType)
        {
            foreach (var tile in _tiles)
            {
                if (tile.type == tileType)
                {
                    Destroy(tile.gameObject);
                    _containerCellCount--;
                    Debug.Log(_containerCellCount);
                }

            }

        }
        private void FreeUpCell(ContainerCell cell)
        {
            if (cell.transform.childCount == 0)
            {
                cell.SetUse(false);
            }
        }


    }
