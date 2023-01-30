using System;

namespace Navigation.View
{
    public interface INavigationView
    {
        event Action OnGameStart;
        event Action OnRestartButtonClick;
        event Action OnMainMenuButtonClick;

        void OnStartButtonClicked();
    }
}