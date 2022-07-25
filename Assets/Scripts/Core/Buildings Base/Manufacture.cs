public abstract class Manufacture : Building {
    public Manufacture(BuildingInfo info, BuildingView buildingView) : base(info, buildingView) {
        type = BuildingType.Manufacture;
    }
}
