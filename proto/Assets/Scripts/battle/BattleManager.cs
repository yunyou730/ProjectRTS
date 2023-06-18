using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ayy
{
    public class BattleManager
    {
        private Battle _battle = null;
        
        public void StartMockBattle()
        {
            MapData mapData = MockMapData();
            
            _battle = new Battle();
            _battle.Start(mapData);
        }
        
        protected MapData MockMapData()
        {
            MapData mapData = new MapData();
            const int rows = 50;
            const int cols = 40;
            mapData.Create(rows,cols);


            var rand = new System.Random();
            for (int row = 0;row < rows;row++)
            {
                for (int col = 0;col < cols;col++)
                {
                    ETileType tileType = (ETileType)rand.Next((int)ETileType.Max);
                    Debug.Log("TileType:" + tileType);
                    mapData.SetTileTypeAt(row,col,tileType);
                }
            }

            return mapData;
        }

        public void OnUpdate()
        {
            if (_battle != null)
            {
                _battle.OnUpdate();
            }
        }

        public void OnDestroy()
        {
            if (_battle != null)
            {
                _battle.OnDestroy();
            }
        }

    }    
}

