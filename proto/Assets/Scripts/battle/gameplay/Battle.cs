using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy
{
    public class Battle
    {
        public MapData mapData = null;
        
        private List<BaseSystem> _systems = new List<BaseSystem>();
        
        public void Start(MapData mapData)
        {
            this.mapData = mapData;
            _systems.Add(new MapVFXSystem(this));

            foreach (var sys in _systems)
            {
                sys.OnStart();
            }
        }
        
        public void OnUpdate()
        {
            foreach (var sys in _systems)
            {
                sys.OnUpdate();
            }
        }

        public void OnDestroy()
        {
            
        }
    }    
}

