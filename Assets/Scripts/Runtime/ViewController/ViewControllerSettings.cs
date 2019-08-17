using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Guido Arkesteijn/ViewControllerSettings", fileName = nameof(ViewControllerSettings))]
public class ViewControllerSettings : ScriptableObject
{
    [SerializeField] private string startPoint;
    [SerializeField] private List<ViewControllerSettingsData> viewData;

    public ViewControllerSettingsData GetStartPointData()
    {
        return viewData.FirstOrDefault(x => x.ID == startPoint);
    }

    public ViewControllerSettingsData GetDataForID(string id)
    {
        return viewData.FirstOrDefault(x => x.ID == id);
    }
}