using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace rts.chess
{
    public class Singleton
    {
        World _world = null;
        
        public Singleton(World world)
        {
            _world = world;
        }
    }
}