using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy
{
    public class PathFinderData
    {
        public Vector2? from = null;
        public Vector2? to = null;
        public PathResult pathResult = null;

        public void Clear()
        {
            from = to = null;
            pathResult = null;
        }
    }
}
