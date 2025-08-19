using UnityEngine;
using Zenject;

public class MainMenuInitializer : MonoBehaviour
{
    [Inject] UIManager manager;
    // Update is called once per frame
    private void Start()
    {
        manager.ShowPanelCorutine(UIPanelEnum.Option);
    }
}
