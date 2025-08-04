using UnityEngine;
using Zenject;

public class AudioManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject audioManagerPrefap;
    public override void InstallBindings()
    {
        // Si audiomanager tiene el monobehaivour
        Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManagerPrefap).AsSingle();
        //Cuando audiomanager no tiene monobehaivour
        //Container.Bind<AudioManager>().AsSingle();
    }
}