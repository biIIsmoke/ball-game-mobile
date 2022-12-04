using Game.View;

namespace Game.Controller
{
    public class GameController
    {
        private IGameView _gameView;

        public GameController(IGameView gameView)
        {
            _gameView = gameView;
            _gameView.OnStartButtonClick += OnStartButtonClicked;
        }

        private void OnStartButtonClicked(int size, int colorCount, int playerCount)
        {
            
        }
    }
}