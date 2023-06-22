using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ayy
{
    public class BattleMetric
    {
        protected int _rows = 0;
        protected int _cols = 0;
        
        public BattleMetric(int nRows,int nCols)
        {
            _rows = nRows;
            _cols = nCols;
        }

        public Vector3 GetTilePosition(int row,int col)
        {
            Vector3 pos = new Vector3(col, 0, row);
            return pos;
        }
        
        public Vector2 ConvertToTilePos(Vector3 pos)
        {
            Vector2 tilePos = new Vector2(pos.x,pos.z);
            return tilePos;
        }

        public Vector3 GetMapCenterPosition()
        {
            return new Vector3(_cols * 0.5f,0.0f,_rows * 0.5f);
        }
    }    
}

