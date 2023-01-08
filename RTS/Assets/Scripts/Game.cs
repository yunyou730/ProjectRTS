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
        
        
        public Game()
        {
            
        }
        
        public void Initialize()
        {
            
        }
        
        public void Dispose()
        {
            
        }
        
        public void StartChess(ChessInfo chessInfo)
        {
            // _world = new GfxWorld();
            
        }
        
        public void ExitChess()
        {
            _world?.Dispose();
        }

        public void OnUpdate(float deltaTime)
        {
            _world?.Update(deltaTime);
        }
    }
    
}
