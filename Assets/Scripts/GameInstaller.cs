using UnityEngine;
using Zenject;
using Game.View;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameView _gameView;
    public override void InstallBindings()
    {
        Container.Bind<IGameView>().To<GameView>().FromInstance(_gameView).AsSingle();
    }
}