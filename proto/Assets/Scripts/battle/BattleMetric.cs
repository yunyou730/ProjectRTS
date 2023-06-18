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
            Vector3 pos = new Vector3(row, 0, col);
            return pos;
        }
    
    }    
}

