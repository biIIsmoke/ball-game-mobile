using System;
using UnityEngine;

namespace Game.View
{
    public interface IGameView
    {
        event Action<int, int, int> OnGameStart;
        event Action<int> OnNextButtonClick;
        event Action OnRestartButtonClick;
        event Action OnMainMenuButtonClick;
        event Action<GameObject> OnFirstBallSelected;
        event Action<GameObject> OnSecondBallSelected;

        void OnStartButtonClicked();
        void OnNextButtonClicked();
        void OnFirstBallSelect(GameObject first);
        void OnSecondBallSelect(GameObject second);
        void UpdateScoreText();
    }
}