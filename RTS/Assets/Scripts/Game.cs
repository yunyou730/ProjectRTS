using System;
using System.Collections;
using System.Collections.Generic;
using rts.chess;
using UnityEngine;


namespace rts
{
    public class Game : IDisposable
    {
        private Chess _chess = null;
        
        public Game()
        {
            
        }
        
        public void Initialize()
        {
            
        }
        
        public void Dispose()
        {
            _chess.Exit();
        }
        
        public void StartChess(ChessInfo chessInfo)
        {
            _chess = new Chess();
            _chess.Start(chessInfo);
        }
        
        public void ExitChess()
        {
            _chess.Exit();   
        }

        public void OnUpdate(float deltaTime)
        {
            _chess?.OnUpdate(deltaTime);
        }
    }
    
}
