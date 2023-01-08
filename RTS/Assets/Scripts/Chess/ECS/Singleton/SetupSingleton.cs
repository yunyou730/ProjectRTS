using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace rts.chess
{
    public class SetupSingleton : Singleton
    {
        World _world = null;
        
        // map info 
        public int TileSize;
        public int MapWidth;
        public int MapHeight;
        public bool HasCreatedChessboard = false;
        
        public SetupSingleton(World world) : base(world)
        {
            
        }
        
        public void FillMapBaseInfo(int tileSize,int mapWidth,int mapHeight)
        {
            HasCreatedChessboard = false;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            TileSize = tileSize;
        }
    }

}