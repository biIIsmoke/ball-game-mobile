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

        public GameRepository()
        {
            BoardSize = 9;
            ColorCount = 2;
            PlayerCount = 2;
        }
        public void Reset()
        {
            FirstBall = null;
            SecondBall = null;
            ActivePlayerIndex = 0;
            IsMovable = true;

            Scores = new List<int>();
            for (int i = 0; i < PlayerCount; i++)
            {
                Scores.Add(0);
            }
        }

        public void IncreasePlayers()
        {
            PlayerCount++;
            if (PlayerCount > 4)
            {
                PlayerCount = 2;
            }
        }

        public void IncreaseBoardSize()
        {
            int dimension = (int)Mathf.Sqrt(BoardSize) + 2;
            if (dimension == 11)
            {
                dimension = 3;
            }
            BoardSize = dimension * dimension;
            ColorCount = 2;
        }

        public void IncreaseColorCount()
        {
            if (ColorCount == 8)
            {
                ColorCount = 2;
                return;
            }

            if ((BoardSize - 1) / 2 == (((BoardSize - 1) / 2) / (ColorCount + 1)) * (ColorCount + 1))
            {
                ColorCount++;
            }
            else
            {
                ColorCount++;
                IncreaseColorCount();
            }
        }
    }
}