using System;
using BallGenerator.View;
using Game.View;

namespace BallGenerator.Controller
{
    public class BallGeneratorController : IDisposable
    {
        private IBallGeneratorView _ballGeneratorView;
        private IGameView _gameView;

        public BallGeneratorController(
            IBallGeneratorView ballGeneratorView,
            IGameView gameView)
        {
            _ballGeneratorView = ballGeneratorView;
            _gameView = gameView;

            _gameView.OnGameStart += OnGameStarted;
            _gameView.OnRestartButtonClick += OnRestartButtonClicked;
            _gameView.OnMainMenuButtonClick += OnMainMenuButtonClicked;
        }

        public void Dispose()
        {
            _gameView.OnGameStart -= OnGameStarted;
        }

        private void OnGameStarted(int size, int colorCount, int playerCount)
        {
            _ballGeneratorView.OnGameStarted(size, colorCount, playerCount);
        }

        private void OnRestartButtonClicked()
        {
            OnMainMenuButtonClicked();
            _gameView.OnStartButtonClicked();
        }
        
        private void OnMainMenuButtonClicked()
        {
            _ballGeneratorView.OnMainMenuButtonClicked();
        }
        
    }
}