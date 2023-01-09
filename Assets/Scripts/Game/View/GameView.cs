using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private List<GameObject> _scores;
        [SerializeField] private Button _nextButton;
        [SerializeField] private int _size = 49;
        [SerializeField] private int _colorCount = 6;
        [SerializeField] private int _playerCount = 2;

        public event Action<int, int> OnGameStart;
        public event Action<int> OnNextButtonClick;
        public event Action<GameObject> OnFirstBallSelected;
        public event Action<GameObject> OnSecondBallSelected;
        
        [Inject]
        public void Construct()
        {
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _nextButton.onClick.AddListener(OnNextButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _nextButton.onClick.AddListener(OnNextButtonClicked);
        }
        private void OnStartButtonClicked()
        {
            OnGameStart?.Invoke(_size, _colorCount);
            
            ActivatePlayers();
            _mainPanel.SetActive(false);
            _inGamePanel.SetActive(true);
        }

        private void OnNextButtonClicked()
        {
            OnNextButtonClick?.Invoke(_playerCount);
        }
        
        private void ActivatePlayers()
        {
            //TODO: creates player tags and score table for them and initializes score list
            for (int i = 0; i < _playerCount; i++)
            {
                var score = _scores[i];
                score.SetActive(true);
            }
        }

        public void OnFirstBallSelect(GameObject first)
        {
            OnFirstBallSelected?.Invoke(first);
        }
        public void OnSecondBallSelect(GameObject second)
        {
            OnSecondBallSelected?.Invoke(second);
        }
    }
}
