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

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void SetTilePosList(List<Vector2> tilePosList)
        {
            if (tilePosList == null)
            {
                Debug.LogWarning("PathLine::SetTilePostList() received empty list");
                return;
            }

            _tilePos = tilePosList;
            
            List<Vector3> points = ConvertTo3DPosList(_tilePos);
            _lineRenderer.SetPositions(points.ToArray());
        }
        
        protected List<Vector3> ConvertTo3DPosList(List<Vector2> tilePosList)
        {
            List<Vector3> result = new List<Vector3>();
            foreach (var tilePos in tilePosList)
            {
                Vector3 point = BattleMetric.GetTilePosition((int)tilePos.y,(int)tilePos.x);
                result.Add(point);
            }
            return result;
        }
    }

}
