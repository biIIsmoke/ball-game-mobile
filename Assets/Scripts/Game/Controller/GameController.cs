using Game.Repository;
using Game.View;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        private IGameView _gameView;
        private IGameRepository _gameRepository;
        
        public GameController(IGameView gameView,
            IGameRepository gameRepository)
        {
            _gameView = gameView;
            _gameRepository = gameRepository;

            _gameView.OnNextButtonClick += OnNextButtonClicked;
            _gameView.OnFirstBallSelected += OnFirstBallSelected;
            _gameView.OnSecondBallSelected += OnSecondBallSelected;
        }

        public void Dispose()
        {
            _gameView.OnNextButtonClick -= OnNextButtonClicked;
            _gameView.OnFirstBallSelected -= OnFirstBallSelected;
            _gameView.OnSecondBallSelected -= OnSecondBallSelected;
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
            if (_gameRepository.FirstBall != null && _gameRepository.SecondBall == null && second != _gameRepository.FirstBall)
            {
                _gameRepository.SecondBall = second;
                Debug.Log($"Second Ball Selected has a color {second.GetComponent<Renderer>().material.color}");
            }
        }
    }
}