using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy
{
    public class MapData
    {
        public int _rowCnt;
        public int _colCnt;
        public ETileType[,] _tileData;
        
        public void Create(int rowCnt,int colCnt)
        {
            _rowCnt = rowCnt;
            _colCnt = colCnt;
            _tileData = new ETileType[_rowCnt, _colCnt];
        }
        
        public void SetTileTypeAt(int row,int col,ETileType tileType)
        {
            _tileData[row, col] = tileType;
        }

        public ETileType GetTileTypeAt(int row,int col)
        {
            if (row < 0 || row >= _rowCnt || col < 0 || col >= _colCnt)
            {
                return ETileType.Invalid;                
            }
            return _tileData[row, col];
        }

        public int GetRowCnt()
        {
            return _rowCnt;
        }

        public int GetColCnt()
        {
            return _colCnt;
        }


    }
    
}
