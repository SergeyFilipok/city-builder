using System;
using System.Collections.Generic;

public class Map {
    private IList<Place> _places;
    private Dictionary<Place, Building> _data;

    public event Action<Place> PlaceClicked;

    public Map(IList<Place> places) {
        _places = places;
        foreach (var pl in _places) {
            pl.Clicked += () => PlaceClicked?.Invoke(pl);
        }
        _data = new Dictionary<Place, Building>(_places.Count, new Place.PlaceEqualityComparer());
    }

    public bool IsEmpty(Place place, out Building building) {
        return _data.TryGetValue(place, out building) == false;
    }

    public void CreateBuilding(IBuildingCreator creator, Place place) {
        if (IsEmpty(place, out var _)) {
            var building = creator.Create();
            building.Position = place.Position;
            _data.Add(place, building);
        }
    }

    public void ReplaceBuilding(Place from, Place to) {
        if (IsEmpty(to, out var _) && IsEmpty(from, out var building) == false) {
            building.Position = to.Position;
            _data.Remove(from);
            _data.Add(to, building);
        }
    }

    public void RemoveBuilding(Place place) {
        if (IsEmpty(place, out var building) == false) {
            _data.Remove(place);
            building.Destroy();
        }
    }
}
