public abstract class Dwelling : Building {
    public Dwelling(BuildingInfo info, BuildingView buildingView) : base(info, buildingView) {
        type = BuildingType.Dwelling;
    }
}
