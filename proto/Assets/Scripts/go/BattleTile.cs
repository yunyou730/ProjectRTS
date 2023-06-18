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


            RefreshPosition();
            RefreshColor();
        }
        
        protected void RefreshPosition()
        {
            transform.localPosition = BattleMetric.GetTilePosition(_row,_col); 
        }

        protected void RefreshColor()
        {
            string materialKey = "battle_tile";
            
            Color col = Color.white;
            switch (_tileType)
            {
                case ETileType.Empty:
                    col = Color.green;
                    materialKey = "battle_tile_empty";
                    break;
                case ETileType.Obstacle:
                    col = Color.red;
                    materialKey = "battle_tile_occupied";
                    break;
                default:
                    break;
            }
            
            _material = GetComponent<MeshRenderer>().sharedMaterial =
                Game.Instance.GetResourceManager().GetMaterial(materialKey, "ayy/BattleTile");
            _material.SetColor(Shader.PropertyToID("_Color"), col);
        }
    }
}
