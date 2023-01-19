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
            
            // create chessboard actor
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
            
            // Create tilemap actor
            GameObject tilemapActor = new GameObject();
            tilemapActor.name = "[tilemap]";
            tilemapActor.transform.SetParent(_root);
            ATileMap aTilemap = tilemapActor.AddComponent<ATileMap>();
            aTilemap.Initialize(_tileMapSingleton,_root);
        }
    }
}
