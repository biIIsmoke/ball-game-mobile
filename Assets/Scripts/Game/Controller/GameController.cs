using Game.View;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        private IGameView _gameView;

        public GameController(IGameView gameView)
        {
            _gameView = gameView;

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
            Debug.Log($"First Ball Selected has a color {first.GetComponent<Renderer>().material.color}");
        }
        private void OnSecondBallSelected(GameObject second)
        {
            Debug.Log($"Second Ball Selected has a color {second.GetComponent<Renderer>().material.color}");
        }
    }
}