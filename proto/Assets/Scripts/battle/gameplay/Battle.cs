using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy
{
    public class Battle
    {
        public MapData mapData = null;
        public PathFinderData pathFinderData = null;
        public BattleMetric metric = null;
        public GameObject rootGO = null;
        
        private List<BaseSystem> _systems = new List<BaseSystem>();
        
        public void Start(MapData mapData,GameObject cameraGO)
        {
            rootGO = new GameObject("[ayy]battle_root");
            
            this.mapData = mapData;
            this.metric = new BattleMetric(mapData._rowCnt,mapData._colCnt);
            this.pathFinderData = new PathFinderData();
            
            _systems.Add(new MapVFXSystem(this));
            _systems.Add(new CameraCtrlSystem(this,cameraGO));
            _systems.Add(new PathFinderVFXSystem(this,cameraGO));
            _systems.Add(new PathFindJobSystem(this));

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

