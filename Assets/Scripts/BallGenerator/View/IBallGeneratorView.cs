using System;
using UnityEngine;

namespace BallGenerator.View
{
    public interface IBallGeneratorView
    {
        void OnGameStarted();
        void OnMainMenuButtonClicked();
        void HideBalls(GameObject first, GameObject second);
    }
}