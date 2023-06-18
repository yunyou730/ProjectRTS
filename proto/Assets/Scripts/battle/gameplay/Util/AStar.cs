using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy
{
    public class AStar
    {
        public static PathResult CalcPath(Vector2 from,Vector2 to,MapData mapData)
        {
            PathResult result = new PathResult();
            result.flag = EPathResult.Fail;
            result.points.Clear();
            
            return result;
        }
    }

    public enum EPathResult
    {
        Success,
        Fail,
        Max
    }

    public class PathResult
    {
        public EPathResult flag;
        public List<Vector2> points;
    }
}
