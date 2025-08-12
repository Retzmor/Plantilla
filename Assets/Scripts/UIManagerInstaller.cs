using UnityEngine;
using Zenject;

public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject prefap;
    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromComponentInNewPrefab(prefap).AsSingle();
    }
}