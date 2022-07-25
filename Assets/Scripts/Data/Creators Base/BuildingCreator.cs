using UnityEngine;

public abstract class BuildingCreator : ScriptableObject {
    public abstract Building Create(BuildingInfo info, BuildingView view);
}
