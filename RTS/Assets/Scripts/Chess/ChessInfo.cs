using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rts.chess
{
    public class ChessInfo
    {
        public readonly int _tileSize;
        public readonly int _mapWidth;
        public readonly int _mapHeight;
        
        public ChessInfo(int tileSize,int mapWidth,int mapHeight)
        {
            _tileSize = tileSize;
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
        }
    }
    
}
