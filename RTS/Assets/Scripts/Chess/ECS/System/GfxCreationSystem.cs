using System.Collections;
using System.Collections.Generic;
using rts.chess.actor;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace rts.chess
{
    public class GfxCreationSystem : System
    {
        private Transform _root = null;
        private SetupSingleton _setupSingleton = null;
        private TileMapSingleton _tileMapSingleton = null;
        
        public GfxCreationSystem(World world) : base(world)
        {
            _setupSingleton = world.GetSingleton<SetupSingleton>(nameof(SetupSingleton));
            _tileMapSingleton = world.GetSingleton<TileMapSingleton>(nameof(TileMapSingleton));
            _root = Entry.Instance.GetRoot();
        }
        
        public override void Tick()
        {
            CreateChessboardAtInit();
            CreateTileMapAtInit();
        }
        
        protected void CreateChessboardAtInit()
        {
            if (_setupSingleton.HasCreatedChessboard)
            {
                return;
            }
            _setupSingleton.HasCreatedChessboard = true;
            
            // Do create actor
            var prefab = Entry.Instance.AssetManager.LoadPrefab("Prefabs/Actors/Chessboard");
            var go = GameObject.Instantiate(prefab);
            go.transform.SetParent(_root);
            go.transform.localPosition = Measure.GetChessboardOrigin(_setupSingleton.MapHeight,_setupSingleton.MapWidth);
            
            var actorChessboard = go.GetComponent<AChessboard>();
            actorChessboard.SetSize(_setupSingleton.MapHeight,_setupSingleton.MapWidth);
            actorChessboard.Refresh();
            
        }

        protected void CreateTileMapAtInit()
        {
            if (_tileMapSingleton.HasCreatedTileMap)
            {
                return;
            }
            _tileMapSingleton.HasCreatedTileMap = true;

            var prefab = Entry.Instance.AssetManager.LoadPrefab("Prefabs/Voxels/Voxel.01");
            for (int row = 0; row < _tileMapSingleton.GetRowCnt();row++)
            {
                for (int col = 0; col < _tileMapSingleton.GetColCnt();col++)
                {
                    Vector3 worldPos = Measure.GetWorldPosAtCoord(row, col);
                    var voxel = GameObject.Instantiate(prefab);
                    voxel.transform.SetParent(_root);
                    voxel.transform.localPosition = worldPos - new Vector3(0.0f,-0.5f,0.0f);


                    _tileMapSingleton.GetType()

                }
            }
        }
    }
}
