using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject gameManager;
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInNewPrefab(gameManager).AsSingle();
    }
}