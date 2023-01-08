using System;
using System.Collections;
using System.Collections.Generic;
using rts.chess;
using UnityEngine;


namespace rts
{
    public class Game : IDisposable
    {
        private World _world = null;
        private float _elapsedTime = 0;
        
        public Game()
        {
            
        }
        
        public void Initialize()
        {
            
        }
        
        public void Dispose()
        {
            ExitChess();
        }
        
        public void StartChess(ChessInfo chessInfo)
        {
            _world = new World(Entry.Instance.LogManager);
            _world.Initialize(chessInfo);
        }
        
        public void ExitChess()
        {
            _world?.Dispose();
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
