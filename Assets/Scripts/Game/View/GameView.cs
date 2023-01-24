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
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private GameObject _MenuPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private List<GameObject> _scores;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        
        //TODO: size, colorcount, playercount fields to change repository
        [SerializeField] private int _size = 49;
        [SerializeField] private int _colorCount = 6;
        [SerializeField] private int _playerCount = 2;

        private IGameRepository _gameRepository;
        public event Action<int, int, int> OnGameStart;
        public event Action<int> OnNextButtonClick;
        public event Action OnRestartButtonClick;
        public event Action OnMainMenuButtonClick;
        public event Action<GameObject> OnFirstBallSelected;
        public event Action<GameObject> OnSecondBallSelected;
        
        [Inject]
        public void Construct(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _nextButton.onClick.AddListener(OnNextButtonClicked);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _nextButton.onClick.RemoveListener(OnNextButtonClicked);
            _menuButton.onClick.RemoveListener(OnMenuButtonClicked);
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }
        
        private void OnMenuButtonClicked()
        {
            _MenuPanel.SetActive(true);
        }
        
        private void OnBackButtonClicked()
        {
            _MenuPanel.SetActive(false);
        }
        
        private void OnRestartButtonClicked()
        {
            _MenuPanel.SetActive(false);
            OnRestartButtonClick?.Invoke();
        }
        
        private void OnMainMenuButtonClicked()
        {
            OnMainMenuButtonClick?.Invoke();
            _MenuPanel.SetActive(false);
            _inGamePanel.SetActive(false);
            _mainPanel.SetActive(true);
        }
        
        private void ActivatePlayers()
        {
            for (int i = 0; i < _playerCount; i++)
            {
                _scores[i].SetActive(true);
                _scores[i].transform.GetChild(0).GetComponent<TMP_Text>().text = _gameRepository.Scores[i].ToString();
            }

            var player2 = _scores[1].transform.GetChild(0);
            
            if (_playerCount == 2)
            {
                player2.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else
            {
                player2.transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        public void OnStartButtonClicked()
        {
            OnGameStart?.Invoke(_size, _colorCount, _playerCount);
            
            ActivatePlayers();
            _mainPanel.SetActive(false);
            _inGamePanel.SetActive(true);
        }
        public void OnNextButtonClicked()
        {
            OnNextButtonClick?.Invoke(_playerCount);
        }

        public void OnFirstBallSelect(GameObject first)
        {
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
