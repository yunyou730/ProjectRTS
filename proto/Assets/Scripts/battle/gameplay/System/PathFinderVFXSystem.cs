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
        
        public PathFinderVFXSystem(Battle battle,GameObject cameraGO) : base(battle)
        {
            _pathFinderData = battle.pathFinderData;
            _cameraGO = cameraGO;
            
            // source & dest 
            var srcPrefab = Resources.Load<GameObject>("PathFinderSource"); 
            var destPrefab = Resources.Load<GameObject>("PathFinderDest");
            _sourceGO = GameObject.Instantiate(srcPrefab);
            _destGO = GameObject.Instantiate(destPrefab);
            _sourceGO.SetActive(false);
            _destGO.SetActive(false);
        }
        
        public override void OnStart()
        {
            
        }
        
        public override void OnUpdate()
        {
            if (HandleSetPoint())
            {
                RefreshSourcePoint();
                RefreshDestPoint();
                RefreshPathLine();         
            }
        }
        
        public override void OnLogicTick()
        {
        }

        public override void OnDestroy()
        {
            
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
                    // Debug.Log("Clicked on " + hit.transform.name);

                    bHit = true;
                    if (_pathFinderData.from == null)
                    {
                        Vector2 tilePos = BattleMetric.ConvertToTilePos(hit.transform.localPosition);
                        _pathFinderData.from = tilePos;
                    }
                    else if (_pathFinderData.to == null)
                    {
                        Vector2 tilePos = BattleMetric.ConvertToTilePos(hit.transform.localPosition);
                        _pathFinderData.to = tilePos;
                    }
                    else
                    {
                        _pathFinderData.Clear();
                    }
                }
            }

            return bHit;
        }

        protected void RefreshSourcePoint()
        {
            if(_pathFinderData.from != null)
            {
                Vector2 from = _pathFinderData.from.Value;
                _sourceGO.SetActive(true);
                Vector3 pos = BattleMetric.GetTilePosition((int)from.y,(int)from.x);
                _sourceGO.transform.localPosition = pos;
            }
            else
            {
                _sourceGO.SetActive(false);
            }
        }

        protected void RefreshDestPoint()
        {
            if(_pathFinderData.to != null)
            {
                Vector2 to = _pathFinderData.to.Value;
                _destGO.SetActive(true);
                Vector3 pos = BattleMetric.GetTilePosition((int)to.y,(int)to.x);
                _destGO.transform.localPosition = pos;
            }
            else
            {
                _destGO.SetActive(false);
            }
        }

        protected void RefreshPathLine()
        {
            
        }

    }    
}

