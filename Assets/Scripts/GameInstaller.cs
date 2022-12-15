using BallGenerator.Controller;
using BallGenerator.View;
using Game.Controller;
using UnityEngine;
using Zenject;
using Game.View;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private BallGeneratorView _ballView;
    public override void InstallBindings()
    {
        Container.Bind<IGameView>().To<GameView>().FromInstance(_gameView).AsSingle();
        Container.Bind<IBallGeneratorView>().To<BallGeneratorView>().FromInstance(_ballView).AsSingle();
        
        Container.Bind<GameController>().AsSingle().NonLazy();
        Container.Bind<BallGeneratorController>().AsSingle().NonLazy();
    }
}