using System.Collections.Generic;
using UnityEngine;

namespace Game.Repository
{
    public class GameRepository : IGameRepository
    {
        public GameObject FirstBall { get; set; }
        public GameObject SecondBall { get; set; }
        public List<int> Scores { get; set; }
        public int ActivePlayerIndex { get; set; }

        public void Reset(int playerCount)
        {
            FirstBall = null;
            SecondBall = null;
            ActivePlayerIndex = 0;

            Scores = new List<int>();
            for (int i = 0; i < playerCount; i++)
            {
                Scores.Add(0);
            }
        }
    }
}