using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ayy
{
    public class BattleMetric
    {
        public static Vector3 GetTilePosition(int row,int col)
        {
            Vector3 pos = new Vector3(col, 0, row);
            return pos;
        }
        
        public static Vector2 ConvertToTilePos(Vector3 pos)
        {
            Vector2 tilePos = new Vector2(pos.x,pos.z);
            return tilePos;
        }

    }    
}

