using System.Collections;
using System.Collections.Generic;
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
            // @miao @todo
            _setupSingleton.HasCreatedChessboard = true;
        }
    }
}
