using System;
using UnityEngine;

[Serializable]
public class ViewControllerSettingsData
{
    public string ID { get { return identifier; } }
    [SerializeField] private string identifier;
    public string ResourcePath { get { return resourcePath; } }
    [SerializeField] private string resourcePath;
}
