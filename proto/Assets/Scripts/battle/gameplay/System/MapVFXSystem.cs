using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ayy
{
    public class MapVFXSystem : BaseSystem
    {
        private GameObject _mapGO = null;

        public MapVFXSystem(Battle battle) : base(battle)
        {
               
        }
        
        public override void OnStart()
        {
            DoCreateMapGameObject();
        }
        
        public override void OnUpdate()
        {
        }

        public override void OnLogicTick()
        {
        }

        public override void OnDestroy()
        {
            
        }

        protected void DoCreateMapGameObject()
        {
            _mapGO = new GameObject("[ayy]BattleMap");
            ayy.go.BattleMap battleMap = _mapGO.AddComponent<ayy.go.BattleMap>();
            battleMap.SetMapData(_battle,_battle.mapData);
        }
    }    
}

