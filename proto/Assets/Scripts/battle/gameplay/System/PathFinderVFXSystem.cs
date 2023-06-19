using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ayy
{
    public class PathFinderVFXSystem : BaseSystem
    {
        private PathFinderData _pathFinderData = null;
        private GameObject _cameraGO = null;
        
        private GameObject _sourceGO = null;
        private GameObject _destGO = null;
        private GameObject _pathLineGO = null;
        
        public PathFinderVFXSystem(Battle battle,GameObject cameraGO) : base(battle)
        {
            _pathFinderData = battle.pathFinderData;
            _cameraGO = cameraGO;
            
            CreateSourceAndDestPoint();
            CreatePathLine();
        }
        
        public override void OnStart()
        {
            
        }
        
        public override void OnUpdate()
        {
            if (HandleSetPoint())
            {
                RefreshPoint(CheckAndGetLastJob().from, _sourceGO);
                RefreshPoint(CheckAndGetLastJob().to, _destGO);
            }
            
            var job = CheckAndGetLastJob();
            if (job != null)
            {
                RefreshPathLine(job);
            }
        }
        
        public override void OnLogicTick()
        {
        }

        public override void OnDestroy()
        {
            
        }

        protected void CreateSourceAndDestPoint()
        {
            var srcPrefab = Resources.Load<GameObject>("PathFinderSource"); 
            var destPrefab = Resources.Load<GameObject>("PathFinderDest");
            _sourceGO = GameObject.Instantiate(srcPrefab);
            _destGO = GameObject.Instantiate(destPrefab);
            _sourceGO.SetActive(false);
            _destGO.SetActive(false);
            
            _sourceGO.transform.SetParent(_battle.rootGO.transform);
            _destGO.transform.SetParent(_battle.rootGO.transform);
        }
        
        protected void CreatePathLine()
        {
            GameObject pathLinePrefab = Resources.Load<GameObject>("PathLine");
            _pathLineGO = Object.Instantiate(pathLinePrefab);
            _pathLineGO.AddComponent<PathLine>();
            _pathLineGO.transform.SetParent(_battle.rootGO.transform);
            _pathLineGO.SetActive(false);
        }

        protected bool HandleSetPoint()
        {
            bool bHit = false;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _cameraGO.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    bHit = true;

                    var job = CheckAndGetLastJob();

                    if (job.from == null)
                    {
                        Vector2 tilePos = BattleMetric.ConvertToTilePos(hit.transform.localPosition);
                        job.from = tilePos;
                    }
                    else if (job.to == null)
                    {
                        Vector2 tilePos = BattleMetric.ConvertToTilePos(hit.transform.localPosition);
                        job.to = tilePos;
                    }
                    else
                    {
                        job.Clear();
                    }
                }
            }
            return bHit;
        }

        protected void RefreshPoint(Vector2? tilePos,GameObject go)
        {
            if (tilePos != null)
            {
                Vector2 tile = tilePos.Value;
                go.SetActive(true);

                Vector3 pos = BattleMetric.GetTilePosition((int)tile.y,(int)tile.x);
                go.transform.localPosition = pos;
            }
            else
            {
                go.SetActive(false);
            }
        }

        protected PathFinderJob CheckAndGetLastJob()
        {
            var job = _pathFinderData.GetLastOneJob();
            if (job == null)
            {
                _pathFinderData.CreateJob();
                job = _pathFinderData.GetLastOneJob();
            }

            return job;
        }

        protected void RefreshPathLine(PathFinderJob job)
        {
            if(job.IsResultReady() && !job.bHasDisplay)
            {
                PathResult result = job.GetResult();
                _pathLineGO.GetComponent<PathLine>().SetTilePosList(result.points);
                job.bHasDisplay = true;
            }
        }
        
    }    
}

