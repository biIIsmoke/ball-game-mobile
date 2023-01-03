using UnityEngine;

namespace Game.Repository
{
    public interface IGameRepository
    {
        bool SetFirstBall(GameObject first);
        GameObject GetFirstBall();
        bool SetSecondBall(GameObject second);
        GameObject GetSecondBall();
    }
}