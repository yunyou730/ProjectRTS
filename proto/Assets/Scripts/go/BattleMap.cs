using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ayy.go
{
    public class BattleMap : MonoBehaviour
    {
        private Battle _battle = null;
        private ayy.MapData _mapData = null;
        private Texture2D _texture = null;

        public void SetMapData(Battle battle,MapData mapData)
        {
            _battle = battle;
            _mapData = mapData;
        }
        
        void Start()
        {
            CreateTexture();
            //CreateTiles();
            CreateMap();
        }

        protected void CreateTexture()
        {
            int width = _mapData.GetColCnt();
            int height = _mapData.GetRowCnt();
            
            _texture = new Texture2D(width,height);
            Color[] pixels = new Color[width * height];
            for (int row = 0;row < height;row++)
            {
                for (int col = 0;col < width;col++)
                {
                    ETileType tileType = _mapData.GetTileTypeAt(row, col);
                    pixels[row * width + col] = tileType == ETileType.Obstacle ? Color.red : Color.green;
                }
            }
            _texture.SetPixels(pixels);
            _texture.Apply();
        }

        protected void CreateMap()
        {
            var prefab = Resources.Load<GameObject>("BattleMap");
            GameObject go = Object.Instantiate(prefab, gameObject.transform, true);
            var mat = go.GetComponent<MeshRenderer>().sharedMaterial;
            mat.SetTexture(Shader.PropertyToID("_MainTex"),_texture);

            int rows = _mapData.GetRowCnt();
            int cols = _mapData.GetColCnt();
            go.transform.localScale = new Vector3(cols,rows,1.0f);
            go.transform.localPosition = _battle.metric.GetMapCenterPosition();
        }
        
        /*
        protected void CreateTiles()
        {
            for (int row = 0;row < _mapData.GetRowCnt();row++)
            {
                for (int col = 0;col < _mapData.GetColCnt();col++)
                {
                    GameObject tilePrefab = Resources.Load<GameObject>("BattleTile");
                    GameObject tileGO = GameObject.Instantiate(tilePrefab, gameObject.transform, true);
                    
                    BattleTile battleTile = tileGO.AddComponent<BattleTile>();
                    ETileType tileType = _mapData.GetTileTypeAt(row, col);
                    battleTile.Refresh(row,col,tileType);
                }
            }
        }
        */

        protected void OnDestroy()
        {
            
        }
    }
}

