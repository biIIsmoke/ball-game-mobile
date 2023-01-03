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

            _gameView.OnFirstBallSelected += OnFirstBallSelected;
            _gameView.OnSecondBallSelected += OnSecondBallSelected;
        }

        public void Dispose()
        {
            _gameView.OnFirstBallSelected -= OnFirstBallSelected;
            _gameView.OnSecondBallSelected -= OnSecondBallSelected;
        }

        private void OnFirstBallSelected(GameObject first)
        {
            if (_gameRepository.SetFirstBall(first))
            {
                Debug.Log($"First Ball Selected has a color {first.GetComponent<Renderer>().material.color}");
            }
        }
        private void OnSecondBallSelected(GameObject second)
        {
            if (_gameRepository.SetSecondBall(second))
            {
                Debug.Log($"Second Ball Selected has a color {second.GetComponent<Renderer>().material.color}");
            }
        }
    }
}