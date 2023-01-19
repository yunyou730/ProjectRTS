using System;
using UnityEngine;

namespace rts.chess.actor
{
    public class ATileMap : MonoBehaviour
    {
        protected string _voxelDefaultPath = "Prefabs/Voxels/Voxel.01";
        protected GameObject _voxelPrefab = null;
        protected TileMapSingleton _tilemap = null;
        protected Transform _root = null;
        
        public void Awake()
        {
            _voxelPrefab = Entry.Instance.AssetManager.LoadPrefab(_voxelDefaultPath);   
        }
        
        public void Initialize(TileMapSingleton tilemap,Transform root)
        {
            _tilemap = tilemap;
            _root = root;
            CreateVoxels();
        }

        protected void CreateVoxels()
        {
            for (int row = 0; row < _tilemap.GetRowCnt(); row++)
            {
                CreateVoxelsForRow(row);
            }
        }

        protected void CreateVoxelsForRow(int row)
        {
            for (int col = 0; col < _tilemap.GetColCnt();col++)
            {
                CreateVoxelsAtTile(row,col);
            }
            
        }

        protected void CreateVoxelsAtTile(int row,int col)
        {
            // Vector3 worldPos = Measure.GetWorldPosAtCoord(row, col);
            TileMapSingleton.Tile tile = _tilemap.GetTileAtCoord(row, col);
            int height = tile.GetHeight();

            for (int h = 1;h < height;h++)
            {
                Vector3 worldPos = Measure.GetWorldPosAtCoordAndHeight(row, col,h);
                    
                var voxel = GameObject.Instantiate(_voxelPrefab);
                voxel.transform.SetParent(_root);
                voxel.transform.localPosition = worldPos - Vector3.up * 0.5f;
            }
        }


    }
}