using System;
using UnityEngine;

namespace Game.View
{
    public interface IGameView
    {
        event Action<int, int> OnGameStart;
        event Action<GameObject> OnFirstBallSelected;
        event Action<GameObject> OnSecondBallSelected;

        void OnFirstBallSelect(GameObject first);

        void OnSecondBallSelect(GameObject second);
    }
}