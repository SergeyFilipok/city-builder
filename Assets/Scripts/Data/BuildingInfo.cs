using System;
using UnityEngine;

[Serializable]
public struct BuildingInfo {
    public Sprite icon;
    public string name;
    [TextArea] 
    public string description;
}
