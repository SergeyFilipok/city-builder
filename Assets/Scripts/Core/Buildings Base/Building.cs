using UnityEngine;

public abstract class Building {
    private BuildingInfo _info;
    private BuildingView _view;

    protected BuildingType type;

    public BuildingInfo Info { get => _info; }
    public BuildingType Type => type;
    public Vector3 Position { get => _view.Position; set => _view.Position = value; }

    public Building(BuildingInfo info, BuildingView buildingView) {
        _view = buildingView;
        _info = info;
    }

    public void Select() {
        _view.Select();
    }

    public void Deselect() {
        _view.Deselect();
    }

    public void Destroy() {
        var tween = _view.Destroy();
        tween.onComplete += () => {
            GameObject.Destroy(_view.gameObject);
        };
    }
}
