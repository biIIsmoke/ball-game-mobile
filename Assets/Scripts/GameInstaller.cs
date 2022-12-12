using Ball.Controller;
using Ball.View;
using Game.Controller;
using UnityEngine;
using Zenject;
using Game.View;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private BallView _ballView;
    public override void InstallBindings()
    {
        Container.Bind<IGameView>().To<GameView>().FromInstance(_gameView).AsSingle();
        Container.Bind<IBallView>().To<BallView>().FromInstance(_ballView).AsSingle();
        
        Container.Bind<GameController>().AsSingle().NonLazy();
        Container.Bind<BallController>().AsSingle().NonLazy();
    }
}