using Ball.View;
using Game.View;
using UnityEngine;

namespace Game.Controller
{
    public class GameController
    {
        private IGameView _gameView;
        private IBallView _ballView;

        public GameController(IGameView gameView,
            IBallView ballView)
        {
            _gameView = gameView;
            _ballView = ballView;

            _ballView.OnFirstBallSelect += OnFirstBallSelected;
            _ballView.OnSecondBallSelect += OnSecondBallSelected;
        }

        public void Dispose()
        {
            _ballView.OnFirstBallSelect -= OnFirstBallSelected;
            _ballView.OnSecondBallSelect -= OnSecondBallSelected;
        }

        private void OnFirstBallSelected(GameObject first)
        {
            Debug.Log("First Ball Selected");
        }
        private void OnSecondBallSelected(GameObject second)
        {
            Debug.Log("Second Ball Selected");
        }
    }
}