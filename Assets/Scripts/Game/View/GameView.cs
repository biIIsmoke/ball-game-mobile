using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        //TODO: instantiate balls using data taken from user
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _startButton;
        [SerializeField] private int _size = 49;
        [SerializeField] private int _colorCount = 6;
        [SerializeField] private int _playerCount = 2;

        public event Action<int, int> OnGameStart;
        
        [Inject]
        public void Construct()
        {
            
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
        }
        private void OnStartButtonClicked()
        {
            OnGameStart?.Invoke(_size, _colorCount);
            
            ActivatePlayers();
            _panel.SetActive(false);
        }
        
        private void ActivatePlayers()
        {
            
        }
    }
}
