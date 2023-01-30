using System;
using System.Collections.Generic;
using Game.Repository;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private List<GameObject> _scores;
        [SerializeField] private Button _nextButton;
        
        private IGameRepository _gameRepository;
        public event Action OnNextButtonClick;
        public event Action<GameObject> OnFirstBallSelected;
        public event Action<GameObject> OnSecondBallSelected;
        
        [Inject]
        public void Construct(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        private void OnEnable()
        {
            _nextButton.onClick.AddListener(OnNextButtonClicked);
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(OnNextButtonClicked);
        }
        
        public void ActivatePlayers()
        {
            for (int i = 0; i < _gameRepository.PlayerCount; i++)
            {
                _scores[i].SetActive(true);
                _scores[i].transform.GetChild(0).GetComponent<TMP_Text>().text = _gameRepository.Scores[i].ToString();
            }

            var player2 = _scores[1].transform.GetChild(0);
            
            if (_gameRepository.PlayerCount == 2)
            {
                player2.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else
            {
                player2.transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        public void OnGameStarted()
        {
            ActivatePlayers();
            _gameRepository.IsMovable = true;
        }
        public void OnNextButtonClicked()
        {
            _gameRepository.IsMovable = true;
            OnNextButtonClick?.Invoke();
        }

        public void OnFirstBallSelect(GameObject first)
        {
            _gameRepository.IsMovable = false;
            OnFirstBallSelected?.Invoke(first);
        }
        public void OnSecondBallSelect(GameObject second)
        {
            OnSecondBallSelected?.Invoke(second);
        }

        public void UpdateScoreText()
        {
            Debug.Log($"Score is: {_gameRepository.Scores[_gameRepository.ActivePlayerIndex]}");
            _scores[_gameRepository.ActivePlayerIndex].transform.GetChild(0).GetComponent<TMP_Text>().text = _gameRepository.Scores[_gameRepository.ActivePlayerIndex].ToString();
        }
    }
}
