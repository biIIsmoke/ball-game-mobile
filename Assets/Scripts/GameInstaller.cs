using Ball.View;
using BallGenerator.Controller;
using BallGenerator.View;
using End.Controller;
using End.View;
using Game.Controller;
using Game.Repository;
using UnityEngine;
using Zenject;
using Game.View;
using Navigation.Controller;
using Navigation.View;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private BallGeneratorView _ballGeneratorView;
    [SerializeField] private NavigationView _navigationView;
    [SerializeField] private EndView _endView;
    [SerializeField] private GameObject _ballPrefab;
    public override void InstallBindings()
    {
        Container.Bind<IGameView>().To<GameView>().FromInstance(_gameView).AsSingle();
        Container.Bind<IGameRepository>().To<GameRepository>().AsSingle();
        Container.Bind<IBallGeneratorView>().To<BallGeneratorView>().FromInstance(_ballGeneratorView).AsSingle();
        Container.Bind<INavigationView>().To<NavigationView>().FromInstance(_navigationView).AsSingle();
        Container.Bind<IEndView>().To<EndView>().FromInstance(_endView).AsSingle();
        
        Container.Bind<GameController>().AsSingle().NonLazy();
        Container.Bind<BallGeneratorController>().AsSingle().NonLazy();
        Container.Bind<NavigationController>().AsSingle().NonLazy();
        Container.Bind<EndController>().AsSingle().NonLazy();

        Container.BindFactory<Camera, GameObject, BallView, BallView.Factory>().FromComponentInNewPrefab(_ballPrefab);
    }
}