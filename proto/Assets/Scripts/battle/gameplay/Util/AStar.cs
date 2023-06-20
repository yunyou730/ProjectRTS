using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace ayy
{
    public class AStar
    {
        public static PathResult CalcPath(Vector2 from,Vector2 to,MapData mapData)
        {
            PathResult result = new PathResult();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // do job 
            AStarFinder finder = new AStarFinder(from,to,mapData);
            // for (int i = 0;i < 100;i++)
            // {
                // finder.Clear();
                finder.DoJob();                
            // }

            
            stopWatch.Stop();
            UnityEngine.Debug.Log("AStarJob Cost" + stopWatch.Elapsed);
            
            
            // hold result
            result.flag = finder.bSucc ? EPathResult.Success : EPathResult.Fail;
            if (finder.bSucc)
            {
                result.points.Clear();

                var parentNode = finder._to;
                while (parentNode != null)
                {
                    result.points.Insert(0,new Vector2(parentNode.x,parentNode.y));
                    parentNode = parentNode.parent;
                }
            }
            return result;
        }
    }


    class AStarNode
    {
        public int x = 0;
        public int y = 0;
        public AStarNode parent = null;
        public float gValue = 0.0f;
        [CanBeNull] private string _key = null;

        public AStarNode(int x,int y)
        {
            this.x = x;
            this.y = y;
            parent = null;
        }
        
        public string Key()
        {
            if (_key == null)
            {
                _key = GenKey(this.x, this.y);
            }
            return _key;
        }

        public static string GenKey(int x,int y)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(x).Append("_").Append(y);
            return sb.ToString();
        }

        public bool IsEqual(AStarNode other)
        {
            return x == other.x && y == other.y;
        }
    }

    class AStarFinder
    {
        private Dictionary<string, AStarNode> openList = new Dictionary<string, AStarNode>();
        private Dictionary<string, AStarNode> closeList = new Dictionary<string, AStarNode>();
        private Dictionary<string, AStarNode> nodePool = new Dictionary<string, AStarNode>();

        public AStarNode _from = null;
        public AStarNode _to = null;
        private MapData _mapData = null;
        
        public bool bSucc = false;

        public AStarFinder(Vector2 from,Vector2 to,MapData mapData)
        {
            _from = GetNode((int)from.x,(int)from.y);
            _to = GetNode((int)to.x, (int)to.y);
            _mapData = mapData;
        }

        protected AStarNode GetNode(int x,int y)
        {
            string key = AStarNode.GenKey(x, y);
            if (!nodePool.ContainsKey(key))
            {
                nodePool.Add(key,new AStarNode(x, y));    
            }
            return nodePool[key];
        }

        public void Clear()
        {
            openList = new Dictionary<string, AStarNode>();
            closeList = new Dictionary<string, AStarNode>();
            bSucc = false;
        }

        public void DoJob()
        {
            var curNode = _from;
            openList.Add(curNode.Key(),curNode);
            curNode.gValue = 0.0f;
            
            while (curNode != null)
            {
                // maintain openList & closeList
                openList.Remove(curNode.Key());
                closeList.Add(curNode.Key(), curNode);

                // neighbors to open list
                List<AStarNode> neighbors = GetNeighbor(curNode);
                foreach (var nb in neighbors)
                {
                    nb.parent = curNode;
                    
                    // check have we found the target tile
                    if (nb.Equals(_to))
                    {
                        // find the result ,reverse parent
                        bSucc = true;
                        return;
                    }
 
                    // update gValue
                    nb.gValue = CalcGValue(nb);
                    // add to open list
                    openList.Add(nb.Key(),nb);
                }
                

                // next cur
                curNode = null;
                float curFValue = 0.0f;
                foreach (var tile in openList.Values)
                {
                    if (curNode == null)
                    {
                        curNode = tile;
                        curFValue = tile.gValue + CalcHValue(tile);
                    }
                    else
                    {
                        float fValue = tile.gValue + CalcHValue(tile);
                        if (fValue < curFValue)
                        {
                            curNode = tile;
                            curFValue = fValue;
                        }
                    }
                }
            }

            
        }

        protected List<AStarNode> GetNeighbor(AStarNode node)
        {
            List<AStarNode> neighbors = new List<AStarNode>();
            
            // 4 directions
            CheckAndAddToNeighborList(neighbors,node.x - 1,node.y);
            CheckAndAddToNeighborList(neighbors,node.x + 1,node.y);
            CheckAndAddToNeighborList(neighbors,node.x,node.y - 1);
            CheckAndAddToNeighborList(neighbors,node.x,node.y + 1);
                
            // 8 directions to be add
            CheckAndAddToNeighborList(neighbors,node.x - 1,node.y - 1);
            CheckAndAddToNeighborList(neighbors,node.x - 1,node.y + 1);
            CheckAndAddToNeighborList(neighbors,node.x + 1,node.y - 1);
            CheckAndAddToNeighborList(neighbors,node.x + 1,node.y + 1);            
            
            return neighbors;
        }

        protected void CheckAndAddToNeighborList(List<AStarNode> neighbors,int x,int y)
        {
            AStarNode node = GetNode(x, y);
            if (IsTileValid(node))
            {
                neighbors.Add(node);
            }
        }

        protected bool IsTileValid(AStarNode node)
        {
            if (node.x < 0 || node.x >= _mapData.GetColCnt() || node.y < 0 || node.y >= _mapData.GetRowCnt())
            {
                return false;
            }
            
            if (!closeList.ContainsKey(node.Key())
                && !openList.ContainsKey(node.Key())
                && _mapData.GetTileTypeAt((int)node.y, (int)node.x) != ETileType.Obstacle)
            {
                return true;
            }
            return false;
        }

        protected float CalcGValue(AStarNode node)
        {
            AStarNode parent = node.parent;
            
            // neighbor G value
            float neigborG = 1.414f;
            if (parent.x == node.x || parent.y == node.y)
            {
                neigborG = 1.0f;
            }
            
            // additive
            float additiveG = parent.gValue;
            return additiveG + neigborG;
        }
        
        // 启发函数, 修改这里能够调整 最终结果   
        protected float CalcHValue(AStarNode tile)
        {
            float hValue = Math.Abs(tile.x - _to.x) + Math.Abs(tile.y - _to.y);
            return hValue;
        }

    }

    public enum EPathResult
    {
        Fail,
        Success,
        Max
    }

    public class PathResult
    {
        public EPathResult flag;
        public List<Vector2> points = null;
        
        public PathResult()
        {
            flag = EPathResult.Fail;
            points = new List<Vector2>();
        }
    }
}

