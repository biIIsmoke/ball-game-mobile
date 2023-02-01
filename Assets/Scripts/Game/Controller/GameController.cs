using BallGenerator.View;
using Game.Repository;
using Game.View;
using Navigation.View;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        private IGameView _gameView;
        private IGameRepository _gameRepository;
        private IBallGeneratorView _ballGeneratorView;
        private INavigationView _navigationView;
        
        public GameController(IGameView gameView,
            IGameRepository gameRepository,
            IBallGeneratorView ballGeneratorView,
            INavigationView navigationView)
        {
            _gameView = gameView;
            _navigationView = navigationView;
            _gameRepository = gameRepository;
            _ballGeneratorView = ballGeneratorView;
            
            _navigationView.OnGameStart += OnGameStarted;
            _gameView.RandomizeStartingPlayer += OnStartingPlayerRandomized;
            _gameView.OnNextButtonClick += OnNextButtonClicked;
            _gameView.OnFirstBallSelected += OnFirstBallSelected;
            _gameView.OnSecondBallSelected += OnSecondBallSelected;
        }

        public void Dispose()
        {
            _navigationView.OnGameStart -= OnGameStarted;
            _gameView.RandomizeStartingPlayer -= OnStartingPlayerRandomized;
            _gameView.OnNextButtonClick -= OnNextButtonClicked;
            _gameView.OnFirstBallSelected -= OnFirstBallSelected;
            _gameView.OnSecondBallSelected -= OnSecondBallSelected;
        }

        private void OnGameStarted()
        {
            _gameRepository.Reset();
            _gameView.OnGameStarted();
        }

        private void OnStartingPlayerRandomized()
        {
            _gameRepository.ActivePlayerIndex = Random.Range(0, _gameRepository.PlayerCount);
        }
        
        private void OnNextButtonClicked()
        {
            if (_gameRepository.ActivePlayerIndex + 1 == _gameRepository.PlayerCount)
            {
                _gameRepository.ActivePlayerIndex = 0;
            }
            else
            {
                _gameRepository.ActivePlayerIndex++;
            }
            Debug.Log(_gameRepository.ActivePlayerIndex);

            _gameRepository.FirstBall = null;
            _gameRepository.SecondBall = null;
        }
        
        private void OnFirstBallSelected(GameObject first)
        { 
            if (_gameRepository.FirstBall == null)
            {
                _gameRepository.FirstBall = first;
                Debug.Log($"First Ball Selected has a color {first.GetComponent<Renderer>().material.color}");
            }
        }
        private void OnSecondBallSelected(GameObject second)
        {
            if ((_gameRepository.FirstBall.transform.position - second.transform.position).magnitude > 1)
            {
                return;
            }
            if (_gameRepository.FirstBall != null && _gameRepository.SecondBall == null && second != _gameRepository.FirstBall)
            {
                _gameRepository.SecondBall = second;
                Debug.Log($"Second Ball Selected has a color {second.GetComponent<Renderer>().material.color}");
            }

            CompareBalls();
        }

        private void CompareBalls()
        {
            if (_gameRepository.FirstBall.GetComponent<Renderer>().material.color == _gameRepository.SecondBall.GetComponent<Renderer>().material.color)
            {
                Debug.Log("Same color balls with");
                _ballGeneratorView.HideBalls(_gameRepository.FirstBall, _gameRepository.SecondBall);
                _gameRepository.Scores[_gameRepository.ActivePlayerIndex]++;
                _gameView.UpdateScoreText();
                _gameView.OnNextButtonClicked();
            }
            else
            {
                _gameView.OnNextButtonClicked();
            }
        }
    }
}