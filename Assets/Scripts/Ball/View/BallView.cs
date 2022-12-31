using System;
using UnityEngine;
using Zenject;

namespace Ball.View
{
    public class BallView : MonoBehaviour, IBallView
    {
        [SerializeField] private Rigidbody _rigidBody;
        private Vector3 _startPos;
        private Vector3 _offset;
        
        public event Action<GameObject> OnFirstBallSelect;
        public event Action<GameObject> OnSecondBallSelect;
        
        [Inject]
        public void Construct()
        {
            
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
                OnFirstBallSelect?.Invoke(gameObject);
            }
            else
            {
                OnSecondBallSelect?.Invoke(gameObject);
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