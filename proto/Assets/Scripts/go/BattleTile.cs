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
        protected ETileType _tileType;
        
        
        public void Refresh(int row,int col,ETileType tileType)
        {
            gameObject.name = "[ayy][" + row + "," + col + "]";
            _row = row;
            _col = col;
            _tileType = tileType;
            
            _material = GetComponent<MeshRenderer>().material = new Material(Shader.Find("ayy/BattleTile"));

            RefreshPosition();
            RefreshColor();
        }
        
        protected void RefreshPosition()
        {
            transform.localPosition = new Vector3(_col,0,_row);
        }

        protected void RefreshColor()
        {
            Color col = Color.white;
            switch (_tileType)
            {
                case ETileType.Empty:
                    col = Color.green;
                    break;
                case ETileType.Obstacle:
                    col = Color.red;
                    break;
                default:
                    break;
            }
            _material.SetColor(Shader.PropertyToID("_Color"), col);
        }
    }
}
