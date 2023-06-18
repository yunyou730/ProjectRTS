using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ayy
{
    public class PathFindJobSystem : BaseSystem
    {
        private PathFinderData _pathFinderData = null;
        private MapData _mapdata = null;
        
        
        public PathFindJobSystem(Battle battle) : base(battle)
        {
            _pathFinderData = battle.pathFinderData;
            _mapdata = battle.mapData;
        }
        
        public override void OnStart()
        {
            
        }
        
        public override void OnUpdate()
        {
            foreach (var job in _pathFinderData.jobs)
            {
                if (job.IsReadyToCalc())
                {
                    PathResult result = AStar.CalcPath(job.from.Value, job.to.Value,_mapdata);
                    job.SetResult(result);
                }
            }
        }
        
        public override void OnLogicTick()
        {
            
        }

        public override void OnDestroy()
        {
            
        }


        
        
    }    
}

