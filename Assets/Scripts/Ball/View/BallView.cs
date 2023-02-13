using System;
using Game.Repository;
using Game.View;
using UnityEngine;
using Zenject;

namespace Ball.View
{
    public class BallView : MonoBehaviour
    {
        private Camera _camera;
        private IGameView _gameView;
        private IGameRepository _gameRepository;
            
        [SerializeField] private Rigidbody _rigidBody;
        private GameObject _placingIndicators;
        private Vector3 _startPos;
        private Vector3 _offset;
        
        [Inject]
        public void Construct(Camera camera, IGameView gameView,
            IGameRepository gameRepository)
        {
            _camera = camera;
            _gameView = gameView;
            _gameRepository = gameRepository;
            _placingIndicators = GameObject.FindWithTag("PlacingIndicators");
        }

        private void OnMouseDown()
        {
            Vector3 cameraVector = _camera.ScreenToWorldPoint(Input.mousePosition);
            _startPos = transform.position;
            if (_gameRepository.IsMovable)
            {
                ShowPlacingIndicators();
            }
            _offset = new Vector3(cameraVector.x,.5f,cameraVector.z) - _startPos;
            _rigidBody.isKinematic = false;
        }

        private void OnMouseDrag()
        {
            if (_gameRepository.IsMovable == false)
            {
                return;
            }
            Vector3 currentPos = GetMousePos() - _offset;
            
            _rigidBody.velocity = (currentPos - transform.position)*10;
        }

        private void OnMouseUp()
        {
            HidePlacingIndicators();
            _rigidBody.isKinematic = true;
            _rigidBody.velocity = Vector3.zero;
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(Mathf.RoundToInt(currentPos.x), .5f, Mathf.RoundToInt(currentPos.z));
            if ((transform.position-_startPos).magnitude > 1)
            {
                transform.position = _startPos;
            }

            if (transform.position != _startPos)
            {
                _gameView.OnFirstBallSelect(gameObject);
            }
            else
            {
                if (_gameRepository.FirstBall != null)
                {
                    _gameView.OnSecondBallSelect(gameObject);
                }
            }
        }

        private Vector3 GetMousePos()
        {
            Vector3 cameraVector = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePos = new Vector3(cameraVector.x,.5f,cameraVector.z);
            return mousePos;
        }

        private void ShowPlacingIndicators()
        {
            float maxPosition = Mathf.Sqrt(_gameRepository.BoardSize) / 2;
            if (_placingIndicators != null)
            {
                GameObject right = _placingIndicators.transform.GetChild(0).gameObject;
                GameObject left = _placingIndicators.transform.GetChild(1).gameObject;
                GameObject up = _placingIndicators.transform.GetChild(2).gameObject;
                GameObject down = _placingIndicators.transform.GetChild(3).gameObject;
                
                if (_startPos.x+1 < maxPosition)
                {
                    right.transform.position = new Vector3(_startPos.x+1,-.4f,_startPos.z);
                    right.SetActive(true);
                }
                if (_startPos.x-1 > -maxPosition)
                {
                    left.transform.position = new Vector3(_startPos.x-1,-.4f,_startPos.z);
                    left.SetActive(true);
                }
                if (_startPos.z+1 < maxPosition)
                {
                    up.transform.position = new Vector3(_startPos.x,-.4f,_startPos.z+1);
                    up.SetActive(true);
                }
                if (_startPos.z-1 > -maxPosition)
                {
                    down.transform.position = new Vector3(_startPos.x,-.4f,_startPos.z-1);
                    down.SetActive(true);
                }
            }
        }

        private void HidePlacingIndicators()
        {
            if (_placingIndicators != null)
            {
                _placingIndicators.transform.GetChild(0).gameObject.SetActive(false);
                _placingIndicators.transform.GetChild(1).gameObject.SetActive(false);
                _placingIndicators.transform.GetChild(2).gameObject.SetActive(false);
                _placingIndicators.transform.GetChild(3).gameObject.SetActive(false);
            }
        }

        public class Factory : PlaceholderFactory<Camera,BallView>
        {
        }
    }
}