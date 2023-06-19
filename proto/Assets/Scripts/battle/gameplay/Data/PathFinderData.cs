using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ayy
{
    public class PathFinderData
    {
        public List<PathFinderJob> jobs = new List<PathFinderJob>();

        public PathFinderJob GetLastOneJob()
        {
            if (jobs != null && jobs.Count > 0)
            {
                return jobs[jobs.Count - 1];
            }

            return null;
        }
        
        public void CreateJob()
        {
            PathFinderJob job = new PathFinderJob();
            jobs.Add(job);
        }
    }
    
    public class PathFinderJob
    {
        public Vector2? from = null;
        public Vector2? to = null;
        public PathResult pathResult = null;
        public bool bHasDisplay = false;
        
        public bool IsReadyToCalc()
        {
            if (from != null && to != null && pathResult == null)
            {
                return true;
            }
            return false;
        }
        

        public bool IsResultReady()
        {
            if (pathResult != null)
            {
                return true;
            }
            return false;
        }

        public PathResult GetResult()
        {
            return pathResult;
        }

        public void SetResult(PathResult result)
        {
            pathResult = result;
        }

        public void Clear()
        {
            from = to = null;
            pathResult = null;
            bHasDisplay = false;
        }
    }
}
