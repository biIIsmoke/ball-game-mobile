using System;
using UnityEngine;
using UnityEngine.UI;

namespace Navigation.View
{
    public class NavigationView : MonoBehaviour, INavigationView
    {
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private GameObject _MenuPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        
        public event Action OnGameStart;
        public event Action OnRestartButtonClick;
        public event Action OnMainMenuButtonClick;
        
        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _menuButton.onClick.AddListener(OnMenuButtonClicked);
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            _menuButton.onClick.RemoveListener(OnMenuButtonClicked);
            _backButton.onClick.RemoveListener(OnBackButtonClicked);
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }
        
        public void OnStartButtonClicked()
        {
            OnGameStart?.Invoke();
            _mainPanel.SetActive(false);
            _inGamePanel.SetActive(true);
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
    }
}