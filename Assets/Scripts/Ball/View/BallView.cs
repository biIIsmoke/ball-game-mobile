using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ball.View
{
    public class BallView : MonoBehaviour, IBallView
    {
        [SerializeField] private Color[] _colors = {Color.red, Color.green, Color.blue, Color.yellow, Color.grey, Color.magenta, Color.black, Color.cyan, Color.clear};
        [SerializeField] private GameObject _board;
        [SerializeField] private GameObject _ball;
        [SerializeField] private GameObject _balls; //place under this
        [SerializeField] private GameObject _pool; //instantiate or send inactive balls under this
        
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

        public void OnGameStarted(int size, int colorCount)
        {
            while (_pool.transform.childCount != size)
            {
                GameObject obj =  Instantiate(_ball, new Vector3(0,0,0),  Quaternion.identity, _pool.transform);
                obj.SetActive(false);
            }

            GameObject board = Instantiate(_board, new Vector3(0, 0, 0), Quaternion.identity);
            float boardSize = Mathf.Sqrt(size)/10;
            board.transform.localScale = new Vector3(boardSize,1,boardSize);

            ColorGenerator(size, colorCount);
            PlaceBalls(boardSize*10);
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
            //place using size to determine positions and activate them
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int poolSize = _pool.transform.childCount;
                    if (poolSize == 0)
                    {
                        return;
                    }
                    int index = Random.Range(0, poolSize);
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
    }
}