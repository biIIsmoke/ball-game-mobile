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
        
        [Inject]
        public void Construct()
        {
            
        }
        
        private void OnEnable()
        {
            
        }

        private void OnDisable()
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
        }

        private void OnMouseUp()
        {
            _rigidBody.isKinematic = true;
            _rigidBody.velocity = Vector3.zero;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), .5f, Mathf.RoundToInt(transform.position.z));
        }

        private Vector3 GetMousePos()
        {
            Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,.5f,Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
            return mousePos;
        }

        public class Factory : PlaceholderFactory<BallView>
        {
        }

        public class PreviewFactory : PlaceholderFactory<BallView>
        {
        }

        public class OpponentHandFactory : PlaceholderFactory<BallView>
        {
        }
    }
}