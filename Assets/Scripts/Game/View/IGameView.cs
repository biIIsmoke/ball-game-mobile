using System;
using UnityEngine;

namespace Game.View
{
    public interface IGameView
    {
        event Action RandomizeStartingPlayer;
        event Action OnNextButtonClick;
        event Action<GameObject> OnFirstBallSelected;
        event Action<GameObject> OnSecondBallSelected;

        void OnGameStarted();
        void OnNextButtonClicked();
        void OnFirstBallSelect(GameObject first);
        void OnSecondBallSelect(GameObject second);
        void UpdateScoreText();
    }
}