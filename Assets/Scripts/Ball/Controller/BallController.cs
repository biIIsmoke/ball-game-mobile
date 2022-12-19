using System;
using Ball.View;
using Game.View;
using UnityEngine;

namespace Ball.Controller
{
    public class BallController : IDisposable
    {
        private IBallView _ballView;
        private IGameView _gameView;

        public BallController(
            IBallView ballView,
            IGameView gameView)
        {
            _ballView = ballView;
            _gameView = gameView;
            
        }

        public void Dispose()
        {
            
        }
    }
}