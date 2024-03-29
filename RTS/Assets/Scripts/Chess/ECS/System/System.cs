using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rts.chess
{
    public abstract class System
    {
        protected World _world { get; }= null;
        
        public System(World world)
        {
            _world = world;
        }
        
        public abstract void Tick();
    }
    
}
