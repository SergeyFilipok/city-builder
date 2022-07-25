using UnityEngine;

[CreateAssetMenu(fileName = "Shop Creator", menuName = "Configs/Buildings/Creators/Shop")]
public class ShopCreator : BuildingCreator {
    public override Building Create(BuildingInfo info, BuildingView view) {
        return new Shop(info, view);
    }
}
