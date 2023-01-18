using UnityEngine;

namespace rts.chess
{
    public class Measure
    {
        protected static float _tileSize = 1;
        protected static float _heightStep = 0.5f;
        protected static float _baseHeight = 0;
        
        void GetTileAtCoord()
        {
            
        }
        
        public static Vector3 GetWorldPosAtCoord(int row,int col)
        {
            float x = col * _tileSize;
            float z = row * _tileSize;
            float y = _baseHeight;
            return new Vector3(x,y,z);
        }

        public static Vector3 GetWorldPosAtCoordAndHeight(int row,int col,int height)
        {
            Vector3 pos = Vector3.zero;
            return pos;
        }

        public static Vector3 GetChessboardOrigin(int rowCnt,int colCnt)
        {
            float height = rowCnt * _tileSize;
            float width = colCnt * _tileSize;
            Vector3 pos = new Vector3(width * 0.5f - 0.5f, _baseHeight - _tileSize, height * 0.5f - 0.5f);
            return pos;
        }
    }
}