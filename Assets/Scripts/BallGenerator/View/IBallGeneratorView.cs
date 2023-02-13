using System;
using UnityEngine;

namespace BallGenerator.View
{
    public interface IBallGeneratorView
    {
        event Action OnGameEnd;
        void OnGameStarted();
        void OnMainMenuButtonClicked();
        void HideBalls(GameObject first, GameObject second);
        bool IsGameEnded();
    }
}