using System;
using Ball.View;
using Game.Repository;
using Navigation.View;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace BallGenerator.View
{
    public class BallGeneratorView : MonoBehaviour, IBallGeneratorView
    {
        [SerializeField] private Color[] _colors = {Color.red, Color.green, Color.blue, Color.yellow, Color.grey, Color.magenta, Color.black, Color.cyan, Color.clear};
        [SerializeField] private GameObject _board;
        [SerializeField] private GameObject _balls;
        [SerializeField] private GameObject _pool;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _placingIndicators;
        
        public event Action OnGameEnd;
        
        private BallView.Factory _ballFactory;
        private IGameRepository _gameRepository;
        
        [Inject]
        public void Construct(BallView.Factory ballFactory,
            IGameRepository gameRepository)
        {
            _ballFactory = ballFactory;
            _gameRepository = gameRepository;
        }
        
        private void ColorGenerator(int size, int colorCount)
        {
            for (int i = 0; i < colorCount; i++)
            {
                for (int j = 0; j < size / colorCount; j++)
                {
                    int index = i * (size/colorCount) + j;
                    GameObject ball = _pool.transform.GetChild(index).gameObject;
                    ball.GetComponent<Renderer>().material.color = _colors[i];
                }
            }
        }

        private void PlaceBalls(float size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int index = Random.Range(0, _gameRepository.BoardSize - (i*(int)size+j));
                    GameObject ball = _pool.transform.GetChild(index).gameObject;
                    ball.transform.position = new Vector3(i-(int)(size/2),.5f,j-(int)(size/2));
                    ball.transform.SetParent(_balls.transform);
                    if (ball.GetComponent<Renderer>().material.color != Color.white)
                    {
                        ball.SetActive(true);
                    }
                }
            }
        }
        public void OnGameStarted()
        {
            while (_pool.transform.childCount < _gameRepository.BoardSize)
            {
                var obj = _ballFactory.Create(_camera, _placingIndicators);
                obj.transform.SetParent(_pool.transform);
                obj.gameObject.SetActive(false);
            }
            float boardSize = Mathf.Sqrt(_gameRepository.BoardSize)/10;
            _board.transform.localScale = new Vector3(boardSize,1,boardSize);
            _board.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1.25f * boardSize, 1.25f * boardSize);
            _board.SetActive(true);
            
            ColorGenerator(_gameRepository.BoardSize, _gameRepository.ColorCount);
            PlaceBalls(boardSize*10);
        }
        
        public void OnMainMenuButtonClicked()
        {
            _board.SetActive(false);
            while (_balls.transform.childCount > 0)
            {
                var ball = _balls.transform.GetChild(0);
                ball.gameObject.SetActive(false);
                ball.transform.SetParent(_pool.transform);
                ball.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        public void HideBalls(GameObject first, GameObject second)
        {
            first.transform.SetParent(_pool.transform);
            first.SetActive(false);
            second.transform.SetParent(_pool.transform);
            second.SetActive(false);

            if (_balls.transform.childCount == 1)
            {
                _balls.transform.GetChild(0).transform.SetParent(_pool.transform);
                OnGameEnd?.Invoke();
            }
        }
    }
}