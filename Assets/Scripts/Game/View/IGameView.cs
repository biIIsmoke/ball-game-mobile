using System;

namespace Game.View
{
    public interface IGameView
    {
        event Action<int,int,int> OnStartButtonClick;
    }
}