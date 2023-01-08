using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace rts.chess
{
    public class Component
    {
        private Entity _entity = null;
        
        public Component(Entity entity)
        {
            _entity = entity;
        }
        
    }
}