using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject UIManagerPrefap;
    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromComponentInNewPrefab(UIManagerPrefap).AsSingle();
    }
}