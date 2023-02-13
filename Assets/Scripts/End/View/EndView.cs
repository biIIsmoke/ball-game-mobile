using System.Linq;
using DG.Tweening;
using Game.Repository;
using UnityEngine;
using Zenject;

namespace End.View
{
    public class EndView : MonoBehaviour, IEndView
    {
        private IGameRepository _gameRepository;

        [SerializeField] private GameObject _winnerArrow;
        [SerializeField] private GameObject _drawResult;
        
        [Inject]
        public void Construct(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        
        public void OnGameEnded()
        {
            int maxScore = _gameRepository.Scores.Max();
            int playercount = _gameRepository.Scores.Count();
            Debug.Log($"playercount is {playercount}");
            int winnerIndex = _gameRepository.Scores.IndexOf(maxScore);
            int occurences = _gameRepository.Scores.Count(x => x.Equals(maxScore));
            
            Debug.Log($" max score is: {maxScore} and it is draw because {occurences}!!!");
            if ( occurences > 1)
            {
                _drawResult.SetActive(true);
                return;
            }
            
            float degree;
            if (_gameRepository.PlayerCount == 2)
            {
                degree = 180 * winnerIndex;
            }
            else
            {
                degree = 90 * winnerIndex;
            }
            Vector3 rotationVector = new Vector3(0, 0, degree + 360);
            float rotationTime = 1 + (degree / 360);
            _winnerArrow.SetActive(true);
            _winnerArrow.transform.DOLocalRotate(rotationVector, rotationTime, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        }

        public void ResetEnd()
        {
            _winnerArrow.transform.rotation = new Quaternion(0, 0, 0, 0);
            _winnerArrow.SetActive(false);
            _drawResult.SetActive(false);
        }
    }
}