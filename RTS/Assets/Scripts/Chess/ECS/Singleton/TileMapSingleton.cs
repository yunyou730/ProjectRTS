using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace rts.chess
{
    public class TileMapSingleton : Singleton
    {
        // Data types
        public enum GroundType
        {
            Common,
            Earth,
            Grass,
        }
        
        public class Tile
        {
            protected int _height;
            protected GroundType _grdType;

            public Tile(int height, GroundType gtype)
            {
                _height = height;
                _grdType = gtype;
            }
            
            public int GetHeight()
            {
                return _height;
            }

            public GroundType GetGroundType()
            {
                return _grdType;
            }
        }
        
        // Members
        World _world = null;

        public bool HasCreatedTileMap = false;
        
        protected int _rowCnt;
        protected int _colCnt;
        
        private Tile[,] _tiles = null;

        public TileMapSingleton(World world) : base(world)
        {
            
        }
        
        
        // Functions
        public void Init(int rowCnt,int colCnt)
        {
            _rowCnt = rowCnt;
            _colCnt = colCnt;
            
            _tiles = new Tile[_rowCnt,_colCnt];
            for (int row = 0;row < _rowCnt;row++)
            {
                for (int col = 0;col < _colCnt;col++)
                {
                    int height = Random.Range(0, 10);
                    _tiles[row, col] = new Tile(height,GroundType.Common);
                }
            }
        }
        
        public Tile GetTileAtCoord(int row,int col)
        {
            if (row < 0 || row >= _rowCnt || col < 0 || col >= _colCnt)
            {
                return null;
            }
            return _tiles[row,col];
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