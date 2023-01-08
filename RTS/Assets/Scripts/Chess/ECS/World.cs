using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace rts.chess
{
    public class World : IDisposable
    {
        private int _eidSeed = 0;
        
        private Entity _rootEntity = null;
        private Dictionary<int, Entity> _entityMap = new Dictionary<int, Entity>();
        private List<System> _systems = new List<System>();
        
        public World()
        {
            CreateRootEntity();
        }
        
        public void Dispose()
        {
            
        }

        protected void RegisterSystems()
        {
            
        }

        public int NextEid()
        {
            _eidSeed++;
            return _eidSeed;
        }

        protected void CreateRootEntity()
        {
            _rootEntity = CreateEntity();
        }
        
        public Entity CreateEntity()
        {
            Entity entity = new Entity(NextEid());
            return entity;
        }
    }
}
