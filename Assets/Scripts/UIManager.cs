using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Collections;

public class UIManager 
{
    [Inject] DiContainer container;
    [SerializeField] UIDatabaseScriptable UIDatabase;
    Dictionary<UIPanelEnum, IUIPanel> panels = new();

    IUIPanel lastPanel;

    public IEnumerator ShowPanelCorutine(UIPanelEnum panelEnum)
    {
        if (!panels.ContainsKey(panelEnum))
        {
            GameObject panelGO = container.InstantiatePrefab(UIDatabase.GetPanelDataByEnum(panelEnum).PanelGO);

            if(panelGO.TryGetComponent(out IUIPanel panel))
            {
                panels.Add(panelEnum, panel);
            }
        }

        if(lastPanel != null)
        {
            lastPanel.Hide();
            yield return new WaitForSeconds(lastPanel.GetAnimationDuration());

        }
        panels[panelEnum].Show();
        yield return new WaitForSeconds(panels[panelEnum].GetAnimationDuration());
    }
}
