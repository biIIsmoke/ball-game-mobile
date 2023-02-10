using System;
using BallGenerator.View;
using Navigation.View;

namespace BallGenerator.Controller
{
    public class BallGeneratorController : IDisposable
    {
        private IBallGeneratorView _ballGeneratorView;
        private INavigationView _navigationView;

        public BallGeneratorController(
            IBallGeneratorView ballGeneratorView,
            INavigationView navigationView)
        {
            _ballGeneratorView = ballGeneratorView;
            _navigationView = navigationView;

            _navigationView.OnGameStart += OnGameStarted;
            _navigationView.OnRestartButtonClick += OnRestartButtonClicked;
            _navigationView.OnMainMenuButtonClick += OnMainMenuButtonClicked;
        }

        public void Dispose()
        {
            _navigationView.OnGameStart -= OnGameStarted;
            _navigationView.OnRestartButtonClick -= OnRestartButtonClicked;
            _navigationView.OnMainMenuButtonClick -= OnMainMenuButtonClicked;
        }

        private void OnGameStarted()
        {
            _ballGeneratorView.OnGameStarted();
        }

        private void OnRestartButtonClicked()
        {
            OnMainMenuButtonClicked();
            _navigationView.OnStartButtonClicked();
        }
        
        private void OnMainMenuButtonClicked()
        {
            _ballGeneratorView.OnMainMenuButtonClicked();
        }
        
    }
}