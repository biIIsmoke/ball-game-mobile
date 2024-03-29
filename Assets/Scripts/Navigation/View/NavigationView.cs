using System;
using Game.Repository;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Navigation.View
{
    public class NavigationView : MonoBehaviour, INavigationView
    {
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _infoPanel;
        [SerializeField] private Button _playersButton;
        [SerializeField] private Button _boardSizeButton;
        [SerializeField] private Button _colorsButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _infoBackButton;
        
        public event Action OnGameStart;
        public event Action OnRestartButtonClick;
        public event Action OnMainMenuButtonClick;
        
        private IGameRepository _gameRepository;
        
        [Inject]
        public void Construct(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            
            _playersButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.PlayerCount} PLAYERS";
            _boardSizeButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.BoardSize} BALLS";
            _colorsButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.ColorCount} COLORS";
        }
        
        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            
            _playersButton.onClick.AddListener(OnPlayersButtonClicked);
            _boardSizeButton.onClick.AddListener(OnBoardSizeButtonClicked);
            _colorsButton.onClick.AddListener(OnColorsButtonClicked);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            _infoButton.onClick.AddListener(OnInfoButtonClicked);
            _infoBackButton.onClick.AddListener(OnInfoBackButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            
            _playersButton.onClick.RemoveListener(OnPlayersButtonClicked);
            _boardSizeButton.onClick.RemoveListener(OnBoardSizeButtonClicked);
            _colorsButton.onClick.RemoveListener(OnColorsButtonClicked);
            _menuButton.onClick.RemoveListener(OnMenuButtonClicked);
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            _infoButton.onClick.RemoveListener(OnInfoButtonClicked);
            _infoBackButton.onClick.RemoveListener(OnInfoBackButtonClicked);
        }
        
        public void OnStartButtonClicked()
        {
            OnGameStart?.Invoke();
            _mainPanel.SetActive(false);
            _infoButton.gameObject.SetActive(false);
            _inGamePanel.SetActive(true);
        }

        private void OnPlayersButtonClicked()
        {
            _gameRepository.IncreasePlayers();
            _playersButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.PlayerCount} PLAYERS";
        }

        private void OnBoardSizeButtonClicked()
        {
            _gameRepository.IncreaseBoardSize();
            _boardSizeButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.BoardSize} BALLS";
            _colorsButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.ColorCount} COLORS";
        }

        private void OnColorsButtonClicked()
        {
            _gameRepository.IncreaseColorCount();
            _colorsButton.transform.GetChild(0).GetComponent<TMP_Text>().text = $"{_gameRepository.ColorCount} COLORS";
        }
        
        private void OnMenuButtonClicked()
        {
            _menuPanel.SetActive(true);
        }
        
        private void OnBackButtonClicked()
        {
            _menuPanel.SetActive(false);
        }
        
        private void OnRestartButtonClicked()
        {
            _menuPanel.SetActive(false);
            OnRestartButtonClick?.Invoke();
        }
        
        private void OnMainMenuButtonClicked()
        {
            OnMainMenuButtonClick?.Invoke();
            _menuPanel.SetActive(false);
            _inGamePanel.SetActive(false);
            _mainPanel.SetActive(true);
            _infoButton.gameObject.SetActive(true);
        }

        private void OnInfoButtonClicked()
        {
            _infoPanel.SetActive(true);
            _infoButton.gameObject.SetActive(false);
        }

        private void OnInfoBackButtonClicked()
        {
            _infoPanel.SetActive(false);
            _infoButton.gameObject.SetActive(true);
        }
    }
}