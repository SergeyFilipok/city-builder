using UnityEngine;

[CreateAssetMenu(fileName = "House Creator", menuName = "Configs/Buildings/Creators/House")]
public class HouseCreator : BuildingCreator {
    public override Building Create(BuildingInfo info, BuildingView view) {
        return new House(info, view);
    }
}
