using System;
using Game.Repository;
using Game.View;
using UnityEngine;
using Zenject;

namespace Ball.View
{
    public class BallView : MonoBehaviour
    {
        private IGameView _gameView;
        private IGameRepository _gameRepository;
            
        [SerializeField] private Rigidbody _rigidBody;
        private Vector3 _startPos;
        private Vector3 _offset;
        
        [Inject]
        public void Construct(IGameView gameView,
            IGameRepository gameRepository)
        {
            _gameView = gameView;
            _gameRepository = gameRepository;
        }

        private void OnMouseDown()
        {
            //highlight the ball and put it in selected tuple
            _startPos = transform.position;
            _offset = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,.5f,Camera.main.ScreenToWorldPoint(Input.mousePosition).z) - _startPos;
            _rigidBody.isKinematic = false;
        }

        private void OnMouseDrag()
        {
            //only transform if it is within 1 unit from start
            Vector3 currentPos = GetMousePos() - _offset;
            if ((currentPos - _startPos).magnitude < 1)
            {
                _rigidBody.velocity = (currentPos - transform.position)*10;
            }

            if ((_startPos - transform.position).magnitude > 1)
            {
                _rigidBody.velocity = Vector3.zero;
            }
        }

        private void OnMouseUp()
        {
            _rigidBody.isKinematic = true;
            _rigidBody.velocity = Vector3.zero;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), .5f, Mathf.RoundToInt(transform.position.z));

            if (transform.position != _startPos) //ball is moved so select it
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
            Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,.5f,Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
            return mousePos;
        }

        public class Factory : PlaceholderFactory<BallView>
        {
        }
    }
}