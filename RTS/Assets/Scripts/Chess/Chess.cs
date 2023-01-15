using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rts.chess
{
    public class Chess
    {
        private World _world = null;
        private float _elapsedTime = 0;
        
        public void Start(ChessInfo chessInfo)
        {
            _world = new World(Entry.Instance.LogManager);
            _world.Initialize(chessInfo);
        }

        public void Exit()
        {
            _world.Dispose();
            _world = null;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_world != null)
            {
                // Handle tick
                _elapsedTime += deltaTime;
                int times = (int)(_elapsedTime / _world.LogicTimeSpan);
                for (int i = 0;i < times;i++)
                {
                    _world.TickLogic();
                }
                _elapsedTime -= times * _world.LogicTimeSpan;
            
                // Handle update
                _world.TickRender();
            }
        }
    }
    
}
