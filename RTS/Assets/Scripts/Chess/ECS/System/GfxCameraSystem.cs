using System.Collections;
using System.Collections.Generic;
using rts.chess.actor;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace rts.chess
{
    public class GfxCameraSystem : System
    {
        private Transform _root = null;
        private SetupSingleton _setupSingleton = null;
        
        public GfxCameraSystem(World world) : base(world)
        {
            
        }
        
        public override void Tick()
        {
                
        }
        
        protected void InitCamera()
        {
            
        }
    }
}