using BallGenerator.View;
using End.View;

namespace End.Controller
{
    public class EndController
    {
        private IEndView _endView;
        private IBallGeneratorView _ballGeneratorView;
        
        public EndController(IEndView endView,
            IBallGeneratorView ballGeneratorView)
        {
            _endView = endView;
            _ballGeneratorView = ballGeneratorView;

            _ballGeneratorView.OnGameEnd += OnGameEnded;
        }

        public void Dispose()
        {
            _ballGeneratorView.OnGameEnd -= OnGameEnded;
        }

        private void OnGameEnded()
        {
            _endView.OnGameEnded();
        }
    }
}