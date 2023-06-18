using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ayy.go
{
    public class BattleMap : MonoBehaviour
    {
        private ayy.MapData _mapData = null;
        private GameObject _rootGO = null;
        
        public void SetMapData(MapData mapData)
        {
            _mapData = mapData;
        }
        
        void Start()
        {
            _rootGO = new GameObject("[ayy]MapRoot");
            CreateTiles();
        }
        
        protected void CreateTiles()
        {
            for (int row = 0;row < _mapData.GetRowCnt();row++)
            {
                for (int col = 0;col < _mapData.GetColCnt();col++)
                {
                    GameObject tilePrefab = Resources.Load<GameObject>("BattleTile");
                    GameObject tileGO = GameObject.Instantiate(tilePrefab, _rootGO.transform, true);
                    
                    BattleTile battleTile = tileGO.AddComponent<BattleTile>();
                    ETileType tileType = _mapData.GetTileTypeAt(row, col);
                    battleTile.Refresh(row,col,tileType);
                }
            }
        }
    }
}

