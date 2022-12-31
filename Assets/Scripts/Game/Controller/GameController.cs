using Ball.View;
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
        }

        public void Dispose()
        {
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