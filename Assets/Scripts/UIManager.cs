using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDatabaseScriptable UIDatabase;
    Dictionary<UIPanelEnum, IUIPanel> panels = new();

    public void ShowPanel(UIPanelEnum panelEnum)
    {
        if (!panels.ContainsKey(panelEnum))
        {
            Instantiate(UIDatabase.GetPanelDataByEnum(panelEnum).PanelGO);
        }
    }
}
