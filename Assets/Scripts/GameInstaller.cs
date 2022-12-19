using Ball.Controller;
using Ball.View;
using BallGenerator.Controller;
using BallGenerator.View;
using Game.Controller;
using UnityEngine;
using Zenject;
using Game.View;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private BallGeneratorView _ballGeneratorView;
    [SerializeField] private BallView _ballViewPrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<BallView, BallView.Factory>().FromComponentInNewPrefab(_ballViewPrefab);
        
        Container.Bind<IGameView>().To<GameView>().FromInstance(_gameView).AsSingle();
        Container.Bind<IBallGeneratorView>().To<BallGeneratorView>().FromInstance(_ballGeneratorView).AsSingle();
        
        Container.Bind<GameController>().AsSingle().NonLazy();
        Container.Bind<BallGeneratorController>().AsSingle().NonLazy();
    }
}