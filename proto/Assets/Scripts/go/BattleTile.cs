using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy.go
{
    public class BattleTile : MonoBehaviour
    {
        private Material _material = null;
        protected int _row;
        protected int _col;
        
        public void Refresh(int row,int col,ETileType tileType)
        {
            gameObject.name = "[ayy][" + row + "," + col + "]";
            _row = row;
            _col = col;
            RefreshPosition();
        }
        
        protected void RefreshPosition()
        {
            transform.localPosition = new Vector3(_col,0,_row);
        }
    }
}
