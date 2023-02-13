using System;
using BallGenerator.View;
using End.View;
using Navigation.View;

namespace BallGenerator.Controller
{
    public class BallGeneratorController : IDisposable
    {
        private IBallGeneratorView _ballGeneratorView;
        private INavigationView _navigationView;
        private IEndView _endView;

        public BallGeneratorController(
            IBallGeneratorView ballGeneratorView,
            INavigationView navigationView,
            IEndView endView)
        {
            _ballGeneratorView = ballGeneratorView;
            _navigationView = navigationView;
            _endView = endView;

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
            _endView.ResetEnd();
        }
    }
}