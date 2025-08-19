using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable_UI_Database", menuName = "New UI Database")]
public class UIDatabaseScriptable : ScriptableObject
{
    [SerializeField] List<UIData> interfaces;

    public UIData GetPanelDataByEnum(UIPanelEnum panelEnum)
    {
        return interfaces.Find(x => x.PanelEnum == panelEnum);
    }

    [Serializable]
    public class UIData
    {
        public UIPanelEnum PanelEnum { get => _panelEnum; set => _panelEnum = value; }
        [SerializeField] UIPanelEnum _panelEnum;
        public GameObject PanelGO { get => _panelGO; set => _panelGO = value; }
        [SerializeField] GameObject _panelGO;
    }
}
