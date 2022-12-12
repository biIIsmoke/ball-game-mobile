using System;
using UnityEngine;

namespace Game.View
{
    public interface IGameView
    {
        event Action<int, int> OnGameStart;
    }
}