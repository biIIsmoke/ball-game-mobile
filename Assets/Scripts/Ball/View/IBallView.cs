using System;
using UnityEngine;

namespace Ball.View
{
    public interface IBallView
    {
        void OnGameStarted(int size, int colorCount);
    }
}