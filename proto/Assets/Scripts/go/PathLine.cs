using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

namespace ayy
{
    public class PathLine : MonoBehaviour
    {
        private List<Vector2> _tilePos = null;  // col:x, row: y
        private LineRenderer _lineRenderer = null;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();   
        }

        void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void SetTilePosList(Battle battle,List<Vector2> tilePosList)
        {
            if (tilePosList == null)
            {
                Debug.LogWarning("PathLine::SetTilePostList() received empty list");
                gameObject.SetActive(false);
                return;
            }
            
            gameObject.SetActive(true);
            _tilePos = tilePosList;
            
            List<Vector3> points = ConvertTo3DPosList(battle,_tilePos);
            _lineRenderer.positionCount = points.Count;
            _lineRenderer.SetPositions(points.ToArray());
        }
        
        protected List<Vector3> ConvertTo3DPosList(Battle battle,List<Vector2> tilePosList)
        {
            List<Vector3> result = new List<Vector3>();
            foreach (var tilePos in tilePosList)
            {
                Vector3 point = battle.metric.GetTilePosition((int)tilePos.y,(int)tilePos.x);
                point.y += 0.1f;    // fix z fighting 
                result.Add(point);
            }
            return result;
        }
    }

}
