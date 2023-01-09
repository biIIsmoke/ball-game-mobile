using System;
using UnityEngine;

namespace BallGenerator.View
{
    public interface IBallGeneratorView
    {
        void OnGameStarted(int size, int colorCount, int playerCount);
        void HideBalls(GameObject first, GameObject second);
    }
}