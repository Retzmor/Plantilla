using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Inject] DiContainer container;
    [SerializeField] UIDatabaseScriptable UIDatabase;
    Dictionary<UIPanelEnum, IUIPanel> panels = new();

    IUIPanel lastPanel;

    public void ShowPanel(UIPanelEnum panelEnum)
    {
        StartCoroutine(ShowPanelCorutine(panelEnum));
    }

    public IEnumerator ShowPanelCorutine(UIPanelEnum panelEnum)
    {
        if (lastPanel != null)
        {
            lastPanel.Hide();
            yield return new WaitForSeconds(lastPanel.GetAnimationDuration());
        }

        if (!panels.ContainsKey(panelEnum))
        {
            GameObject panelGO = container.InstantiatePrefab(UIDatabase.GetPanelDataByEnum(panelEnum).PanelGO);

            if(panelGO.TryGetComponent(out IUIPanel panel))
            {
                panels.Add(panelEnum, panel);
            }
        }
        panels[panelEnum].Show();
        yield return new WaitForSeconds(panels[panelEnum].GetAnimationDuration());
        lastPanel = panels[panelEnum];
    }
}
