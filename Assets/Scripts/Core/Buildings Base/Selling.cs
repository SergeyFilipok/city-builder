public abstract class Selling : Building {
    public Selling(BuildingInfo info, BuildingView buildingView) : base(info, buildingView) {
        type = BuildingType.Selling;
    }
}
