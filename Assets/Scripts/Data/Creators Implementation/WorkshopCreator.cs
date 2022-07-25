using UnityEngine;

[CreateAssetMenu(fileName = "Workshop Creator", menuName = "Configs/Buildings/Creators/Workshop")]
public class WorkshopCreator : BuildingCreator {
    public override Building Create(BuildingInfo info, BuildingView view) {
        return new Workshop(info, view);
    }
}
