using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View
{
    public class GameView : MonoBehaviour, IGameView
    {
        //TODO: instantiate balls using data taken from user
        [SerializeField] private GameObject _balls; //instantiate under this
        [SerializeField] private GameObject _pool; //send inactive balls under this
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _startButton;
        [SerializeField] private int _size = 49;
        [SerializeField] private int _colorCount = 3;
        [SerializeField] private int _playerCount = 2;

        public event Action<int,int,int> OnStartButtonClick;
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
            OnStartButtonClick?.Invoke(_size, _colorCount, _playerCount);
            _panel.SetActive(false);
        }
    }
}
