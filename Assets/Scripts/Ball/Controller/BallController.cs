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

            _gameView.OnGameStart += OnGameStarted;
        }

        public void Dispose()
        {
            _gameView.OnGameStart -= OnGameStarted;
        }

        private void OnGameStarted(int size, int colorCount)
        {
            //call view to start the game
            Debug.Log("GameStarted");
            _ballView.OnGameStarted(size, colorCount);
        }
        
    }
}