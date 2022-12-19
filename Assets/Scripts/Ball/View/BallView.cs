using System;
using UnityEngine;
using Zenject;

namespace Ball.View
{
    public class BallView : MonoBehaviour, IBallView
    {
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
        }

        private void OnMouseDrag()
        {
            //only transform if it is within 1 unit from start
            if ((GetMousePos() - _offset - _startPos).magnitude < 1)
            {
                transform.position = GetMousePos() - _offset;
            }
        }

        private void OnMouseUp()
        {
            transform.position = new Vector3((int)transform.position.x, .5f, (int)transform.position.z);
            Debug.Log(transform.position);
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