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
        private Vector3 _startPos;
        private Vector3 _offset;
        
        [Inject]
        public void Construct(IGameView gameView,
            IGameRepository gameRepository)
        {
            _camera = Camera.main;
            _gameView = gameView;
            _gameRepository = gameRepository;
        }

        private void OnMouseDown()
        {
            Vector3 cameraVector = _camera.ScreenToWorldPoint(Input.mousePosition);
            _startPos = transform.position;
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

        public class Factory : PlaceholderFactory<BallView>
        {
        }
    }
}