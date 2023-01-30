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
        public bool IsMovable { get; set; }
        
        //TODO: modify these to remember stuff
        public int BoardSize { get; set; }
        public int ColorCount { get; set; }
        public int PlayerCount { get; set; }
        public void Reset()
        {
            FirstBall = null;
            SecondBall = null;
            ActivePlayerIndex = 0;
            IsMovable = true;
            BoardSize = 49;
            ColorCount = 6;
            PlayerCount = 2;

            Scores = new List<int>();
            for (int i = 0; i < PlayerCount; i++)
            {
                Scores.Add(0);
            }
        }
    }
}