using System;
using BallGenerator.View;
using Game.View;

namespace BallGenerator.Controller
{
    public class BallGeneratorController : IDisposable
    {
        private IBallGeneratorView _ballView;
        private IGameView _gameView;

        public BallGeneratorController(
            IBallGeneratorView ballView,
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
            _ballView.OnGameStarted(size, colorCount);
        }
        
    }
}