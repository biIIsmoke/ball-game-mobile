using BallGenerator.View;
using Game.Repository;
using Game.View;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        private IGameView _gameView;
        private IGameRepository _gameRepository;
        private IBallGeneratorView _ballGeneratorView;
        
        public GameController(IGameView gameView,
            IGameRepository gameRepository,
            IBallGeneratorView ballGeneratorView)
        {
            _gameView = gameView;
            _gameRepository = gameRepository;
            _ballGeneratorView = ballGeneratorView;
            
            _gameView.OnGameStart += OnGameStarted;
            _gameView.OnNextButtonClick += OnNextButtonClicked;
            _gameView.OnFirstBallSelected += OnFirstBallSelected;
            _gameView.OnSecondBallSelected += OnSecondBallSelected;
        }

        public void Dispose()
        {
            _gameView.OnGameStart += OnGameStarted;
            _gameView.OnNextButtonClick -= OnNextButtonClicked;
            _gameView.OnFirstBallSelected -= OnFirstBallSelected;
            _gameView.OnSecondBallSelected -= OnSecondBallSelected;
        }

        private void OnGameStarted(int size, int colorCount, int playerCount)
        {
            _gameRepository.Reset(playerCount);
        }
        
        private void OnNextButtonClicked(int playerCount)
        {
            if (_gameRepository.ActivePlayerIndex + 1 == playerCount)
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