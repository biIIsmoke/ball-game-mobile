using Game.Repository;
using UnityEngine;
using Zenject;

namespace End.View
{
    public class EndView : MonoBehaviour, IEndView
    {
        private IGameRepository _gameRepository;

        [SerializeField] private GameObject _endPanel;
        [SerializeField] private Sprite _winnerArrow;
        
        [Inject]
        public void Construct(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public void OnGameEnded()
        {
            _endPanel.SetActive(true);
            //dotween animation
            
        }
    }
}