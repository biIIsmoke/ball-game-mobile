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

        public GameRepository()
        {
            FirstBall = null;
            SecondBall = null;
            //add 0 to Scores list for each player
            ActivePlayerIndex = 0;
        }
    }
}