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
        public GfxCreationSystem(World world) : base(world)
        {
            _setupSingleton = world.GetSingleton<SetupSingleton>(nameof(SetupSingleton));
            _root = Entry.Instance.GetRoot();
        }
        
        public override void Tick()
        {
            CheckAndCreateChessboard();
        }
        
        protected void CheckAndCreateChessboard()
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
            var actorChessboard = go.GetComponent<AChessboard>();
            actorChessboard.SetSize(_setupSingleton.MapHeight,_setupSingleton.MapWidth);
            actorChessboard.Refresh();
        }
    }
}
