using System.Collections.Generic;
using UnityEngine;

namespace Game.Repository
{
    public class GameRepository : IGameRepository
    {
        //TODO: Use { get; set; } , ditch the functions
        private GameObject FirstBall;
        private GameObject SecondBall;
        private List<int> Scores;
        private int ActivePlayerIndex;

        public GameRepository(int playerCount)
        {
            FirstBall = null;
            SecondBall = null;
            //add 0 to Scores list for each player
            ActivePlayerIndex = 0;
        }
        public bool SetFirstBall(GameObject first)
        {
            if (FirstBall == null)
            {
                FirstBall = first;
                return true;
            }
            return false;
        }

        public GameObject GetFirstBall()
        {
            return FirstBall;
        }
        
        public bool SetSecondBall(GameObject second)
        {
            if (FirstBall == null)
            {
                return false;
            }
            if (SecondBall == null && FirstBall != second)
            {
                SecondBall = second;
                return true;
            }
            return false;
        }
        
        public GameObject GetSecondBall()
        {
            return SecondBall;
        }
    }
}